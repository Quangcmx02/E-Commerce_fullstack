<template>
    <div class="w-full rounded-lg border border-zinc-700 bg-zinc-800">
        <!-- Araç Çubuğu -->
        <div class="flex flex-wrap items-center gap-1 border-b border-zinc-700 p-2">
            <!-- Metin Biçimlendirme -->
            <div class="flex items-center space-x-1">
                <button
                    v-for="format in textFormats"
                    :key="format.command"
                    @click="execCommand(format.command)"
                    class="rounded p-1.5 hover:bg-zinc-700"
                    :class="{ 'bg-zinc-700': isFormatActive(format.command) }"
                    :title="format.label"
                >
                    <component :is="format.icon" class="h-4 w-4 text-white" />
                </button>
            </div>

            <div class="h-6 w-px bg-zinc-700"></div>

            <!-- Liste Biçimlendirme -->
            <div class="flex items-center space-x-1">
                <button
                    v-for="list in listFormats"
                    :key="list.command"
                    @click="execCommand(list.command)"
                    class="rounded p-1.5 hover:bg-zinc-700"
                    :title="list.label"
                >
                    <component :is="list.icon" class="h-4 w-4 text-white" />
                </button>
            </div>

            <div class="h-6 w-px bg-zinc-700"></div>

            <!-- Hizalama -->
            <div class="flex items-center space-x-1">
                <button
                    v-for="align in alignFormats"
                    :key="align.command"
                    @click="execCommand(align.command)"
                    class="rounded p-1.5 hover:bg-zinc-700"
                    :title="align.label"
                >
                    <component :is="align.icon" class="h-4 w-4 text-white" />
                </button>
            </div>

            <div class="h-6 w-px bg-zinc-700"></div>

            <!-- Bağlantı Ekleme -->
            <button
                @click="addLink"
                class="rounded p-1.5 hover:bg-zinc-700"
                title="Bağlantı Ekle"
            >
                <LinkIcon class="h-4 w-4 text-white" />
            </button>

            <!-- Resim Ekleme -->
            <button
                @click="addImage"
                class="rounded p-1.5 hover:bg-zinc-700"
                title="Resim Ekle"
            >
                <PhotoIcon class="h-4 w-4 text-white" />
            </button>
        </div>

        <!-- Editör Alanı -->
        <div
            ref="editorRef"
            class="min-h-[200px] p-4 text-white focus:outline-none"
            contenteditable="true"
            @input="handleInput"
            @paste="handlePaste"
        ></div>
    </div>
</template>

<script setup lang="ts">
import { ref, onMounted, watch } from 'vue';
import { 
    BoltIcon as BoldIcon,
    DocumentTextIcon as ItalicIcon,
    MinusIcon as UnderlineIcon,
    XMarkIcon as StrikethroughIcon,
    ListBulletIcon,
    QueueListIcon as ListNumberIcon,
    ArrowLeftIcon as AlignLeftIcon,
    ArrowsPointingInIcon as AlignCenterIcon,
    ArrowRightIcon as AlignRightIcon,
    ArrowsPointingOutIcon as AlignJustifyIcon,
    LinkIcon,
    PhotoIcon
} from '@heroicons/vue/24/outline';

interface Props {
    modelValue?: string;
    placeholder?: string;
}

const props = withDefaults(defineProps<Props>(), {
    modelValue: '',
    placeholder: 'İçeriğinizi buraya yazın...',
});

const emit = defineEmits(['update:modelValue']);

const editorRef = ref<HTMLElement>();

const textFormats = [
    { command: 'bold', label: 'Kalın', icon: BoldIcon },
    { command: 'italic', label: 'İtalik', icon: ItalicIcon },
    { command: 'underline', label: 'Altı Çizili', icon: UnderlineIcon },
    { command: 'strikeThrough', label: 'Üstü Çizili', icon: StrikethroughIcon },
];

const listFormats = [
    { command: 'insertUnorderedList', label: 'Sırasız Liste', icon: ListBulletIcon },
    { command: 'insertOrderedList', label: 'Sıralı Liste', icon: ListNumberIcon },
];

const alignFormats = [
    { command: 'justifyLeft', label: 'Sola Hizala', icon: AlignLeftIcon },
    { command: 'justifyCenter', label: 'Ortala', icon: AlignCenterIcon },
    { command: 'justifyRight', label: 'Sağa Hizala', icon: AlignRightIcon },
    { command: 'justifyFull', label: 'İki Yana Yasla', icon: AlignJustifyIcon },
];

onMounted(() => {
    if (editorRef.value) {
        editorRef.value.innerHTML = props.modelValue;
    }
});

watch(() => props.modelValue, (newValue) => {
    if (editorRef.value && editorRef.value.innerHTML !== newValue) {
        editorRef.value.innerHTML = newValue;
    }
});

const execCommand = (command: string, value: string | null = null) => {
    document.execCommand(command, false, value);
    editorRef.value?.focus();
};

const isFormatActive = (command: string) => {
    return document.queryCommandState(command);
};

const handleInput = () => {
    emit('update:modelValue', editorRef.value?.innerHTML || '');
};

const handlePaste = (event: ClipboardEvent) => {
    event.preventDefault();
    const text = event.clipboardData?.getData('text/plain');
    if (text) {
        document.execCommand('insertText', false, text);
    }
};

const addLink = () => {
    const url = prompt('Bağlantı URL\'si:', 'https://');
    if (url) {
        execCommand('createLink', url);
    }
};

const addImage = () => {
    const url = prompt('Resim URL\'si:', 'https://');
    if (url) {
        execCommand('insertImage', url);
    }
};
</script> 