<template>
    <div class="container py-8">
        <div class="flex gap-8">
            <div class="sticky top-20 h-fit w-72 rounded-lg border border-zinc-800 bg-zinc-900/50 p-4 backdrop-blur hidden">
                <nav class="space-y-1">
                    <a href="#button" class="block rounded-md px-3 py-2 text-sm text-zinc-200 hover:bg-zinc-800 hover:text-white">Button</a>
                    <a href="#input" class="block rounded-md px-3 py-2 text-sm text-zinc-200 hover:bg-zinc-800 hover:text-white">Input</a>
                    <a href="#select" class="block rounded-md px-3 py-2 text-sm text-zinc-200 hover:bg-zinc-800 hover:text-white">Select</a>
                    <a href="#loading" class="block rounded-md px-3 py-2 text-sm text-zinc-200 hover:bg-zinc-800 hover:text-white">Loading</a>
                    <a href="#alert" class="block rounded-md px-3 py-2 text-sm text-zinc-200 hover:bg-zinc-800 hover:text-white">Alert</a>
                    <a href="#badge" class="block rounded-md px-3 py-2 text-sm text-zinc-200 hover:bg-zinc-800 hover:text-white">Badge</a>
                    <a href="#table" class="block rounded-md px-3 py-2 text-sm text-zinc-200 hover:bg-zinc-800 hover:text-white">Table</a>
                    <a href="#checkbox" class="block rounded-md px-3 py-2 text-sm text-zinc-200 hover:bg-zinc-800 hover:text-white">Checkbox</a>
                    <a href="#radio" class="block rounded-md px-3 py-2 text-sm text-zinc-200 hover:bg-zinc-800 hover:text-white">Radio</a>
                    <a href="#textarea" class="block rounded-md px-3 py-2 text-sm text-zinc-200 hover:bg-zinc-800 hover:text-white">Textarea</a>
                    <a href="#datepicker" class="block rounded-md px-3 py-2 text-sm text-zinc-200 hover:bg-zinc-800 hover:text-white">Date Picker</a>
                    <a href="#fileupload" class="block rounded-md px-3 py-2 text-sm text-zinc-200 hover:bg-zinc-800 hover:text-white">File Upload</a>
                    <a href="#list" class="block rounded-md px-3 py-2 text-sm text-zinc-200 hover:bg-zinc-800 hover:text-white">List</a>
                    <a href="#navigation-components" class="block rounded-md px-3 py-2 text-sm text-zinc-200 hover:bg-zinc-800 hover:text-white">Navigasyon Bileşenleri</a>
                    <a href="#helper-components" class="block rounded-md px-3 py-2 text-sm text-zinc-200 hover:bg-zinc-800 hover:text-white">Yardımcı Bileşenler</a>
                    <a href="#card-components" class="block rounded-md px-3 py-2 text-sm text-zinc-200 hover:bg-zinc-800 hover:text-white">Kart Bileşenleri</a>
                    <a href="#modal-dialog-components" class="block rounded-md px-3 py-2 text-sm text-zinc-200 hover:bg-zinc-800 hover:text-white">Modal ve Dialog Bileşenleri</a>
                    <a href="#loader-components" class="block rounded-md px-3 py-2 text-sm text-zinc-200 hover:bg-zinc-800 hover:text-white">Yükleme ve Durum Bileşenleri</a>
                    <a href="#switch" class="block rounded-md px-3 py-2 text-sm text-zinc-200 hover:bg-zinc-800 hover:text-white">Switch</a>
                    <a href="#slider" class="block rounded-md px-3 py-2 text-sm text-zinc-200 hover:bg-zinc-800 hover:text-white">Slider</a>
                    <a href="#colorpicker" class="block rounded-md px-3 py-2 text-sm text-zinc-200 hover:bg-zinc-800 hover:text-white">Color Picker</a>
                    <a href="#tree" class="block rounded-md px-3 py-2 text-sm text-zinc-200 hover:bg-zinc-800 hover:text-white">Tree</a>
                    <a href="#layout-components" class="block rounded-md px-3 py-2 text-sm text-zinc-200 hover:bg-zinc-800 hover:text-white">Düzen Bileşenleri</a>
                    <a href="#notification-components" class="block rounded-md px-3 py-2 text-sm text-zinc-200 hover:bg-zinc-800 hover:text-white">Bildirim ve Geri Bildirim</a>
                </nav>
            </div>

            <div class="flex-1 space-y-12">
                <!-- Header -->
                <div class="mb-12">
                    <h1 class="text-3xl font-bold text-white mb-4">UI Kit</h1>
                    <p class="text-gray-400">Bu sayfa, UI bileşenlerinin kullanımını ve özelliklerini gösterir.</p>
                </div>

                <!-- Button Documentation -->
                <section id="button" class="space-y-8">
                    <div class="border-b border-border pb-4">
                        <h2 class="text-2xl font-bold text-white">Button</h2>
                        <p class="text-gray-400 mt-2">Çok yönlü, özelleştirilebilir button bileşeni.</p>
                    </div>

                    <!-- Import Section -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Import</h3>
                        <div class="border border-border p-4 rounded-md">
                            <code class="text-sm text-gray-300">import Button from '@/components/ui/Button.vue'</code>
                        </div>
                    </div>

                    <!-- Props Section -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Props</h3>
                        <div class="overflow-x-auto">
                            <table class="w-full text-left border-collapse">
                                <thead>
                                    <tr class="border-b border-border">
                                        <th class="py-3 text-gray-400">Prop</th>
                                        <th class="py-3 text-gray-400">Tip</th>
                                        <th class="py-3 text-gray-400">Varsayılan</th>
                                        <th class="py-3 text-gray-400">Açıklama</th>
                                    </tr>
                                </thead>
                                <tbody class="text-gray-300">
                                    <tr class="border-b border-border">
                                        <td class="py-3 font-medium">variant</td>
                                        <td>string</td>
                                        <td>'primary'</td>
                                        <td>Button'un görsel stili (primary, secondary, outline, ghost, danger, success)</td>
                                    </tr>
                                    <tr class="border-b border-border">
                                        <td class="py-3 font-medium">size</td>
                                        <td>string</td>
                                        <td>'md'</td>
                                        <td>Button'un boyutu (sm, md, lg)</td>
                                    </tr>
                                    <tr class="border-b border-border">
                                        <td class="py-3 font-medium">loading</td>
                                        <td>boolean</td>
                                        <td>false</td>
                                        <td>Yükleniyor durumunu gösterir</td>
                                    </tr>
                                    <tr class="border-b border-border">
                                        <td class="py-3 font-medium">disabled</td>
                                        <td>boolean</td>
                                        <td>false</td>
                                        <td>Button'u devre dışı bırakır</td>
                                    </tr>
                                    <tr class="border-b border-border">
                                        <td class="py-3 font-medium">className</td>
                                        <td>string</td>
                                        <td>''</td>
                                        <td>Ek CSS sınıfları eklemek için</td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>

                    <!-- Button Variants Section -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Varyantlar</h3>
                        <div class="p-6 border border-border rounded-lg space-y-6">
                            <div class="flex flex-wrap gap-4">
                                <Button variant="primary">Primary</Button>
                                <Button variant="secondary">Secondary</Button>
                                <Button variant="outline">Outline</Button>
                                <Button variant="ghost">Ghost</Button>
                                <Button variant="danger">Danger</Button>
                                <Button variant="success">Success</Button>
                            </div>
                            <div class="bg-muted/40 p-4 rounded-md">
                                <code class="text-sm text-gray-300">
                                    &lt;Button variant="primary"&gt;Primary&lt;/Button&gt;
                                    <br />
                                    &lt;Button variant="secondary"&gt;Secondary&lt;/Button&gt;
                                    <br />
                                    &lt;Button variant="outline"&gt;Outline&lt;/Button&gt;
                                    <br />
                                    &lt;Button variant="ghost"&gt;Ghost&lt;/Button&gt;
                                    <br />
                                    &lt;Button variant="danger"&gt;Danger&lt;/Button&gt;
                                    <br />
                                    &lt;Button variant="success"&gt;Success&lt;/Button&gt;
                                </code>
                            </div>
                        </div>
                    </div>

                    <!-- Button Sizes Section -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Boyutlar</h3>
                        <div class="p-6 border border-border rounded-lg space-y-6">
                            <div class="flex flex-wrap items-center gap-4">
                                <Button size="sm">Small</Button>
                                <Button size="md">Medium</Button>
                                <Button size="lg">Large</Button>
                            </div>
                            <div class="bg-muted/40 p-4 rounded-md">
                                <code class="text-sm text-gray-300">
                                    &lt;Button size="sm"&gt;Small&lt;/Button&gt;
                                    <br />
                                    &lt;Button size="md"&gt;Medium&lt;/Button&gt;
                                    <br />
                                    &lt;Button size="lg"&gt;Large&lt;/Button&gt;
                                </code>
                            </div>
                        </div>
                    </div>

                    <!-- Button States Section -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Durumlar</h3>
                        <div class="p-6 border border-border rounded-lg space-y-6">
                            <div class="flex flex-wrap gap-4">
                                <Button loading>Yükleniyor</Button>
                                <Button disabled>Devre Dışı</Button>
                            </div>
                            <div class="bg-muted/40 p-4 rounded-md">
                                <code class="text-sm text-gray-300">
                                    &lt;Button loading&gt;Yükleniyor&lt;/Button&gt;
                                    <br />
                                    &lt;Button disabled&gt;Devre Dışı&lt;/Button&gt;
                                </code>
                            </div>
                        </div>
                    </div>
                </section>

                <!-- Input Documentation -->
                <section id="input" class="space-y-8 mt-16">
                    <div class="border-b border-border pb-4">
                        <h2 class="text-2xl font-bold text-white">Input</h2>
                        <p class="text-gray-400 mt-2">Form girişleri için çok yönlü input bileşeni.</p>
                    </div>

                    <!-- Import Section -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Import</h3>
                        <div class="border border-border p-4 rounded-md">
                            <code class="text-sm text-gray-300">import Input from '@/components/ui/Input.vue'</code>
                        </div>
                    </div>

                    <!-- Props Section -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Props</h3>
                        <div class="overflow-x-auto">
                            <table class="min-w-full divide-y divide-border">
                                <thead>
                                    <tr>
                                        <th scope="col" class="py-3.5 pl-4 pr-3 text-left text-sm font-semibold text-white">Prop</th>
                                        <th scope="col" class="px-3 py-3.5 text-left text-sm font-semibold text-white">Type</th>
                                        <th scope="col" class="px-3 py-3.5 text-left text-sm font-semibold text-white">Default</th>
                                        <th scope="col" class="px-3 py-3.5 text-left text-sm font-semibold text-white">Description</th>
                                    </tr>
                                </thead>
                                <tbody class="divide-y divide-border">
                                    <tr>
                                        <td class="whitespace-nowrap py-4 pl-4 pr-3 text-sm font-medium text-white">modelValue</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">String | Number</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">undefined</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">Input değeri</td>
                                    </tr>
                                    <tr>
                                        <td class="whitespace-nowrap py-4 pl-4 pr-3 text-sm font-medium text-white">type</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">String</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">'text'</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">Input tipi (text, email, password, number)</td>
                                    </tr>
                                    <tr>
                                        <td class="whitespace-nowrap py-4 pl-4 pr-3 text-sm font-medium text-white">variant</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">String</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">'default'</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">Input varyantı (default, filled, outline, ghost)</td>
                                    </tr>
                                    <tr>
                                        <td class="whitespace-nowrap py-4 pl-4 pr-3 text-sm font-medium text-white">size</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">String</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">'md'</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">Input boyutu (sm, md, lg)</td>
                                    </tr>
                                    <tr>
                                        <td class="whitespace-nowrap py-4 pl-4 pr-3 text-sm font-medium text-white">error</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">String</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">''</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">Hata mesajı</td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>

                    <!-- Input Variants Section -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Varyantlar</h3>
                        <div class="p-6 border border-border rounded-lg space-y-6">
                            <div class="max-w-sm space-y-4">
                                <Input variant="default" placeholder="Default variant" />
                                <Input variant="filled" placeholder="Filled variant" />
                                <Input variant="outline" placeholder="Outline variant" />
                                <Input variant="ghost" placeholder="Ghost variant" />
                            </div>
                            <div class="bg-muted/40 p-4 rounded-md">
                                <code class="text-sm text-gray-300">
                                    &lt;Input variant="default" placeholder="Default variant" /&gt;
                                    <br />
                                    &lt;Input variant="filled" placeholder="Filled variant" /&gt;
                                    <br />
                                    &lt;Input variant="outline" placeholder="Outline variant" /&gt;
                                    <br />
                                    &lt;Input variant="ghost" placeholder="Ghost variant" /&gt;
                                </code>
                            </div>
                        </div>
                    </div>

                    <!-- Input Types Section -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Input Tipleri</h3>
                        <div class="p-6 border border-border rounded-lg space-y-6">
                            <div class="max-w-sm space-y-4">
                                <Input type="text" placeholder="Text input" />
                                <Input type="email" placeholder="Email input" />
                                <Input type="password" placeholder="Password input" />
                                <Input type="number" placeholder="Number input" />
                            </div>
                            <div class="bg-muted/40 p-4 rounded-md">
                                <code class="text-sm text-gray-300">
                                    &lt;Input type="text" placeholder="Text input" /&gt;
                                    <br />
                                    &lt;Input type="email" placeholder="Email input" /&gt;
                                    <br />
                                    &lt;Input type="password" placeholder="Password input" /&gt;
                                    <br />
                                    &lt;Input type="number" placeholder="Number input" /&gt;
                                </code>
                            </div>
                        </div>
                    </div>

                    <!-- Input Sizes Section -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Boyutlar</h3>
                        <div class="p-6 border border-border rounded-lg space-y-6">
                            <div class="max-w-sm space-y-4">
                                <Input size="sm" placeholder="Small input" />
                                <Input size="md" placeholder="Medium input" />
                                <Input size="lg" placeholder="Large input" />
                            </div>
                            <div class="bg-muted/40 p-4 rounded-md">
                                <code class="text-sm text-gray-300">
                                    &lt;Input size="sm" placeholder="Small input" /&gt;
                                    <br />
                                    &lt;Input size="md" placeholder="Medium input" /&gt;
                                    <br />
                                    &lt;Input size="lg" placeholder="Large input" /&gt;
                                </code>
                            </div>
                        </div>
                    </div>

                    <!-- Input States Section -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Durumlar</h3>
                        <div class="p-6 border border-border rounded-lg space-y-6">
                            <div class="max-w-sm space-y-4">
                                <Input label="Normal" placeholder="Normal input" />
                                <Input label="Disabled" placeholder="Disabled input" disabled />
                                <Input label="With Error" placeholder="Error input" error="Bu alan zorunludur" />
                                <Input label="With Helper" placeholder="Helper text" helperText="Bu alana kullanıcı adınızı girin" />
                            </div>
                            <div class="bg-muted/40 p-4 rounded-md">
                                <code class="text-sm text-gray-300">
                                    &lt;Input label="Normal" placeholder="Normal input" /&gt;
                                    <br />
                                    &lt;Input label="Disabled" placeholder="Disabled input" disabled /&gt;
                                    <br />
                                    &lt;Input label="With Error" placeholder="Error input" error="Bu alan zorunludur" /&gt;
                                    <br />
                                    &lt;Input label="With Helper" placeholder="Helper text" helperText="Bu alana kullanıcı adınızı girin" /&gt;
                                </code>
                            </div>
                        </div>
                    </div>
                </section>

                <!-- Select Documentation -->
                <section id="select" class="space-y-8 mt-16">
                    <div class="border-b border-border pb-4">
                        <h2 class="text-2xl font-bold text-white">Select</h2>
                        <p class="text-gray-400 mt-2">Seçim yapmak için kullanılan dropdown bileşeni.</p>
                    </div>

                    <!-- Import Section -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Import</h3>
                        <div class="border border-border p-4 rounded-md">
                            <code class="text-sm text-gray-300">import Select from '@/components/ui/Select.vue'</code>
                        </div>
                    </div>

                    <!-- Props Section -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Props</h3>
                        <div class="overflow-x-auto">
                            <table class="min-w-full divide-y divide-border">
                                <thead>
                                    <tr>
                                        <th scope="col" class="py-3.5 pl-4 pr-3 text-left text-sm font-semibold text-white">Prop</th>
                                        <th scope="col" class="px-3 py-3.5 text-left text-sm font-semibold text-white">Type</th>
                                        <th scope="col" class="px-3 py-3.5 text-left text-sm font-semibold text-white">Default</th>
                                        <th scope="col" class="px-3 py-3.5 text-left text-sm font-semibold text-white">Description</th>
                                    </tr>
                                </thead>
                                <tbody class="divide-y divide-border">
                                    <tr>
                                        <td class="whitespace-nowrap py-4 pl-4 pr-3 text-sm font-medium text-white">modelValue</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">String | Number | Array</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">undefined</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">Seçilen değer(ler)</td>
                                    </tr>
                                    <tr>
                                        <td class="whitespace-nowrap py-4 pl-4 pr-3 text-sm font-medium text-white">options</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">Array</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">[]</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">Seçenekler listesi</td>
                                    </tr>
                                    <tr>
                                        <td class="whitespace-nowrap py-4 pl-4 pr-3 text-sm font-medium text-white">multiple</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">Boolean</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">false</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">Çoklu seçim özelliği</td>
                                    </tr>
                                    <tr>
                                        <td class="whitespace-nowrap py-4 pl-4 pr-3 text-sm font-medium text-white">searchable</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">Boolean</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">false</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">Arama özelliği</td>
                                    </tr>
                                    <tr>
                                        <td class="whitespace-nowrap py-4 pl-4 pr-3 text-sm font-medium text-white">variant</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">String</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">'default'</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">Select varyantı (default, filled, outline, ghost)</td>
                                    </tr>
                                    <tr>
                                        <td class="whitespace-nowrap py-4 pl-4 pr-3 text-sm font-medium text-white">size</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">String</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">'md'</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">Select boyutu (sm, md, lg)</td>
                                    </tr>
                                    <tr>
                                        <td class="whitespace-nowrap py-4 pl-4 pr-3 text-sm font-medium text-white">placeholder</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">String</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">''</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">Varsayılan seçenek metni</td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>

                    <!-- Select Variants Section -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Varyantlar</h3>
                        <div class="p-6 border border-border rounded-lg space-y-6">
                            <div class="max-w-sm space-y-4">
                                <Select variant="default" placeholder="Default variant">
                                    <option value="1">Seçenek 1</option>
                                    <option value="2">Seçenek 2</option>
                                    <option value="3">Seçenek 3</option>
                                </Select>
                                <Select variant="filled" placeholder="Filled variant">
                                    <option value="1">Seçenek 1</option>
                                    <option value="2">Seçenek 2</option>
                                    <option value="3">Seçenek 3</option>
                                </Select>
                                <Select variant="outline" placeholder="Outline variant">
                                    <option value="1">Seçenek 1</option>
                                    <option value="2">Seçenek 2</option>
                                    <option value="3">Seçenek 3</option>
                                </Select>
                                <Select variant="ghost" placeholder="Ghost variant">
                                    <option value="1">Seçenek 1</option>
                                    <option value="2">Seçenek 2</option>
                                    <option value="3">Seçenek 3</option>
                                </Select>
                            </div>
                            <div class="bg-muted/40 p-4 rounded-md">
                                <code class="text-sm text-gray-300">
                                    &lt;Select variant="default" placeholder="Default variant"&gt;
                                    <br />
                                    &nbsp;&nbsp;&lt;option value="1"&gt;Seçenek 1&lt;/option&gt;
                                    <br />
                                    &nbsp;&nbsp;&lt;option value="2"&gt;Seçenek 2&lt;/option&gt;
                                    <br />
                                    &nbsp;&nbsp;&lt;option value="3"&gt;Seçenek 3&lt;/option&gt;
                                    <br />
                                    &lt;/Select&gt;
                                </code>
                            </div>
                        </div>
                    </div>

                    <!-- Select Sizes Section -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Boyutlar</h3>
                        <div class="p-6 border border-border rounded-lg space-y-6">
                            <div class="max-w-sm space-y-4">
                                <Select size="sm" placeholder="Small select">
                                    <option value="1">Seçenek 1</option>
                                    <option value="2">Seçenek 2</option>
                                    <option value="3">Seçenek 3</option>
                                </Select>
                                <Select size="md" placeholder="Medium select">
                                    <option value="1">Seçenek 1</option>
                                    <option value="2">Seçenek 2</option>
                                    <option value="3">Seçenek 3</option>
                                </Select>
                                <Select size="lg" placeholder="Large select">
                                    <option value="1">Seçenek 1</option>
                                    <option value="2">Seçenek 2</option>
                                    <option value="3">Seçenek 3</option>
                                </Select>
                            </div>
                            <div class="bg-muted/40 p-4 rounded-md">
                                <code class="text-sm text-gray-300">
                                    &lt;Select size="sm" placeholder="Small select"&gt;...&lt;/Select&gt;
                                    <br />
                                    &lt;Select size="md" placeholder="Medium select"&gt;...&lt;/Select&gt;
                                    <br />
                                    &lt;Select size="lg" placeholder="Large select"&gt;...&lt;/Select&gt;
                                </code>
                            </div>
                        </div>
                    </div>

                    <!-- Select States Section -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Durumlar</h3>
                        <div class="p-6 border border-border rounded-lg space-y-6">
                            <div class="max-w-sm space-y-4">
                                <Select label="Normal" placeholder="Normal select">
                                    <option value="1">Seçenek 1</option>
                                    <option value="2">Seçenek 2</option>
                                    <option value="3">Seçenek 3</option>
                                </Select>
                                <Select label="Disabled" placeholder="Disabled select" disabled>
                                    <option value="1">Seçenek 1</option>
                                    <option value="2">Seçenek 2</option>
                                    <option value="3">Seçenek 3</option>
                                </Select>
                                <Select label="With Error" placeholder="Error select" error="Bu alan zorunludur">
                                    <option value="1">Seçenek 1</option>
                                    <option value="2">Seçenek 2</option>
                                    <option value="3">Seçenek 3</option>
                                </Select>
                                <Select label="With Helper" placeholder="Helper select" helperText="Lütfen bir seçenek seçin">
                                    <option value="1">Seçenek 1</option>
                                    <option value="2">Seçenek 2</option>
                                    <option value="3">Seçenek 3</option>
                                </Select>
                            </div>
                            <div class="bg-muted/40 p-4 rounded-md">
                                <code class="text-sm text-gray-300">
                                    &lt;Select label="Normal" placeholder="Normal select"&gt;...&lt;/Select&gt;
                                    <br />
                                    &lt;Select label="Disabled" placeholder="Disabled select" disabled&gt;...&lt;/Select&gt;
                                    <br />
                                    &lt;Select label="With Error" placeholder="Error select" error="Bu alan zorunludur"&gt;...&lt;/Select&gt;
                                    <br />
                                    &lt;Select label="With Helper" placeholder="Helper select" helperText="Lütfen bir seçenek seçin"&gt;...&lt;/Select&gt;
                                </code>
                            </div>
                        </div>
                    </div>

                    <!-- Select Features Section -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Özellikler</h3>
                        <div class="p-6 border border-border rounded-lg space-y-6">
                            <div class="max-w-sm space-y-4">
                                <!-- Basic Select -->
                                <Select
                                    label="Temel Select"
                                    placeholder="Bir seçenek seçin"
                                    :options="[
                                        { label: 'Seçenek 1', value: '1' },
                                        { label: 'Seçenek 2', value: '2' },
                                        { label: 'Seçenek 3', value: '3' },
                                    ]"
                                />

                                <!-- Searchable Select -->
                                <Select
                                    label="Arama Özellikli Select"
                                    placeholder="Seçeneklerde arama yapın"
                                    :options="[
                                        { label: 'Elma', value: '1' },
                                        { label: 'Armut', value: '2' },
                                        { label: 'Muz', value: '3' },
                                        { label: 'Portakal', value: '4' },
                                        { label: 'Mandalina', value: '5' },
                                    ]"
                                    searchable
                                />

                                <!-- Multiple Select -->
                                <Select
                                    label="Çoklu Seçim"
                                    placeholder="Birden fazla seçim yapın"
                                    :options="[
                                        { label: 'JavaScript', value: '1' },
                                        { label: 'TypeScript', value: '2' },
                                        { label: 'Vue.js', value: '3' },
                                        { label: 'React', value: '4' },
                                        { label: 'Angular', value: '5' },
                                    ]"
                                    multiple
                                />

                                <!-- Multiple Searchable Select -->
                                <Select
                                    label="Çoklu Seçim ve Arama"
                                    placeholder="Arama yapın ve birden fazla seçin"
                                    :options="[
                                        { label: 'İstanbul', value: '1' },
                                        { label: 'Ankara', value: '2' },
                                        { label: 'İzmir', value: '3' },
                                        { label: 'Bursa', value: '4' },
                                        { label: 'Antalya', value: '5' },
                                    ]"
                                    multiple
                                    searchable
                                />
                            </div>
                            <div class="bg-muted/40 p-4 rounded-md">
                                <code class="text-sm text-gray-300">
                                    &lt;!-- Temel Select --&gt;
                                    <br />
                                    &lt;Select
                                    <br />
                                    &nbsp;&nbsp;placeholder="Bir seçenek seçin"
                                    <br />
                                    &nbsp;&nbsp;:options="[
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;{ label: 'Seçenek 1', value: '1' },
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;{ label: 'Seçenek 2', value: '2' },
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;{ label: 'Seçenek 3', value: '3' }
                                    <br />
                                    &nbsp;&nbsp;]"
                                    <br />
                                    /&gt;
                                    <br />
                                    <br />
                                    &lt;!-- Arama Özellikli Select --&gt;
                                    <br />
                                    &lt;Select
                                    <br />
                                    &nbsp;&nbsp;searchable
                                    <br />
                                    &nbsp;&nbsp;placeholder="Seçeneklerde arama yapın"
                                    <br />
                                    &nbsp;&nbsp;:options="options"
                                    <br />
                                    /&gt;
                                    <br />
                                    <br />
                                    &lt;!-- Çoklu Seçim --&gt;
                                    <br />
                                    &lt;Select
                                    <br />
                                    &nbsp;&nbsp;multiple
                                    <br />
                                    &nbsp;&nbsp;placeholder="Birden fazla seçim yapın"
                                    <br />
                                    &nbsp;&nbsp;:options="options"
                                    <br />
                                    /&gt;
                                    <br />
                                    <br />
                                    &lt;!-- Çoklu Seçim ve Arama --&gt;
                                    <br />
                                    &lt;Select
                                    <br />
                                    &nbsp;&nbsp;multiple
                                    <br />
                                    &nbsp;&nbsp;searchable
                                    <br />
                                    &nbsp;&nbsp;placeholder="Arama yapın ve birden fazla seçin"
                                    <br />
                                    &nbsp;&nbsp;:options="options"
                                    <br />
                                    /&gt;
                                </code>
                            </div>
                        </div>
                    </div>
                </section>

                <!-- Loading Documentation -->
                <section id="loading" class="space-y-8 mt-16">
                    <div class="border-b border-border pb-4">
                        <h2 class="text-2xl font-bold text-white">Loading</h2>
                        <p class="text-gray-400 mt-2">Yükleme durumunu gösteren spinner bileşeni.</p>
                    </div>

                    <!-- Import Section -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Import</h3>
                        <div class="border border-border p-4 rounded-md">
                            <code class="text-sm text-gray-300">import Loading from '@/components/ui/Loading.vue'</code>
                        </div>
                    </div>

                    <!-- Loading Variants Section -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Varyantlar</h3>
                        <div class="p-6 border border-border rounded-lg space-y-6">
                            <div class="flex flex-wrap gap-8">
                                <Loading variant="primary" text="Yükleniyor..." />
                                <Loading variant="secondary" text="Yükleniyor..." />
                                <Loading variant="success" text="Yükleniyor..." />
                                <Loading variant="warning" text="Yükleniyor..." />
                                <Loading variant="danger" text="Yükleniyor..." />
                                <Loading variant="info" text="Yükleniyor..." />
                            </div>
                            <div class="bg-muted/40 p-4 rounded-md">
                                <code class="text-sm text-gray-300">
                                    &lt;Loading variant="primary" text="Yükleniyor..." /&gt;
                                    <br />
                                    &lt;Loading variant="secondary" text="Yükleniyor..." /&gt;
                                    <br />
                                    &lt;Loading variant="success" text="Yükleniyor..." /&gt;
                                    <br />
                                    &lt;Loading variant="warning" text="Yükleniyor..." /&gt;
                                    <br />
                                    &lt;Loading variant="danger" text="Yükleniyor..." /&gt;
                                    <br />
                                    &lt;Loading variant="info" text="Yükleniyor..." /&gt;
                                </code>
                            </div>
                        </div>
                    </div>

                    <!-- Loading Sizes Section -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Boyutlar</h3>
                        <div class="p-6 border border-border rounded-lg space-y-6">
                            <div class="flex flex-wrap items-center gap-8">
                                <Loading size="sm" text="Küçük" />
                                <Loading size="md" text="Orta" />
                                <Loading size="lg" text="Büyük" />
                            </div>
                            <div class="bg-muted/40 p-4 rounded-md">
                                <code class="text-sm text-gray-300">
                                    &lt;Loading size="sm" text="Küçük" /&gt;
                                    <br />
                                    &lt;Loading size="md" text="Orta" /&gt;
                                    <br />
                                    &lt;Loading size="lg" text="Büyük" /&gt;
                                </code>
                            </div>
                        </div>
                    </div>
                </section>

                <!-- Alert Documentation -->
                <section id="alert" class="space-y-8 mt-16">
                    <div class="border-b border-border pb-4">
                        <h2 class="text-2xl font-bold text-white">Alert</h2>
                        <p class="text-gray-400 mt-2">Kullanıcıya bilgi, başarı, uyarı veya hata mesajları göstermek için kullanılan bileşen.</p>
                    </div>

                    <!-- Import Section -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Import</h3>
                        <div class="border border-border p-4 rounded-md">
                            <code class="text-sm text-gray-300">import Alert from '@/components/ui/Alert.vue'</code>
                        </div>
                    </div>

                    <!-- Alert Variants Section -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Varyantlar</h3>
                        <div class="p-6 border border-border rounded-lg space-y-6">
                            <div class="space-y-4">
                                <Alert variant="info" title="Bilgi" message="Bu bir bilgi mesajıdır." />
                                <Alert variant="success" title="Başarılı" message="İşlem başarıyla tamamlandı." />
                                <Alert variant="warning" title="Uyarı" message="Bu bir uyarı mesajıdır." />
                                <Alert variant="danger" title="Hata" message="Bir hata oluştu." />
                            </div>
                            <div class="bg-muted/40 p-4 rounded-md">
                                <code class="text-sm text-gray-300">
                                    &lt;Alert
                                    <br />
                                    &nbsp;&nbsp;variant="info"
                                    <br />
                                    &nbsp;&nbsp;title="Bilgi"
                                    <br />
                                    &nbsp;&nbsp;message="Bu bir bilgi mesajıdır."
                                    <br />
                                    /&gt;
                                </code>
                            </div>
                        </div>
                    </div>

                    <!-- Alert Features Section -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Özellikler</h3>
                        <div class="p-6 border border-border rounded-lg space-y-6">
                            <div class="max-w-sm space-y-4">
                                <Alert variant="info" title="İkon ile" message="İkonlu alert mesajı" icon />
                                <Alert variant="success" title="Kapatılabilir" message="Bu alert kapatılabilir." dismissible />
                                <Alert variant="warning">
                                    <template #default>
                                        <div class="flex items-center">
                                            <span class="font-medium">Özel İçerik:</span>
                                            <span class="ml-2">Slot kullanarak özel içerik ekleyebilirsiniz.</span>
                                        </div>
                                    </template>
                                </Alert>
                            </div>
                            <div class="bg-muted/40 p-4 rounded-md">
                                <code class="text-sm text-gray-300">
                                    &lt;Alert
                                    <br />
                                    &nbsp;&nbsp;variant="info"
                                    <br />
                                    &nbsp;&nbsp;title="İkon ile"
                                    <br />
                                    &nbsp;&nbsp;message="İkonlu alert mesajı"
                                    <br />
                                    &nbsp;&nbsp;icon
                                    <br />
                                    /&gt;
                                    <br />
                                    <br />
                                    &lt;Alert
                                    <br />
                                    &nbsp;&nbsp;variant="success"
                                    <br />
                                    &nbsp;&nbsp;title="Kapatılabilir"
                                    <br />
                                    &nbsp;&nbsp;message="Bu alert kapatılabilir."
                                    <br />
                                    &nbsp;&nbsp;dismissible
                                    <br />
                                    /&gt;
                                </code>
                            </div>
                        </div>
                    </div>
                </section>

                <!-- Badge Documentation -->
                <section id="badge" class="space-y-8 mt-16">
                    <div class="border-b border-border pb-4">
                        <h2 class="text-2xl font-bold text-white">Badge</h2>
                        <p class="text-gray-400 mt-2">Durum, etiket veya sayı göstermek için kullanılan rozet bileşeni.</p>
                    </div>

                    <!-- Import Section -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Import</h3>
                        <div class="border border-border p-4 rounded-md">
                            <code class="text-sm text-gray-300">import Badge from '@/components/ui/Badge.vue'</code>
                        </div>
                    </div>

                    <!-- Badge Variants Section -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Varyantlar</h3>
                        <div class="p-6 border border-border rounded-lg space-y-6">
                            <div class="flex flex-wrap gap-4">
                                <Badge variant="primary" text="Primary" />
                                <Badge variant="secondary" text="Secondary" />
                                <Badge variant="success" text="Success" />
                                <Badge variant="warning" text="Warning" />
                                <Badge variant="danger" text="Danger" />
                                <Badge variant="info" text="Info" />
                            </div>
                            <div class="bg-muted/40 p-4 rounded-md">
                                <code class="text-sm text-gray-300">
                                    &lt;Badge variant="primary" text="Primary" /&gt;
                                    <br />
                                    &lt;Badge variant="secondary" text="Secondary" /&gt;
                                    <br />
                                    &lt;Badge variant="success" text="Success" /&gt;
                                    <br />
                                    &lt;Badge variant="warning" text="Warning" /&gt;
                                    <br />
                                    &lt;Badge variant="danger" text="Danger" /&gt;
                                    <br />
                                    &lt;Badge variant="info" text="Info" /&gt;
                                </code>
                            </div>
                        </div>
                    </div>

                    <!-- Badge Sizes Section -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Boyutlar</h3>
                        <div class="p-6 border border-border rounded-lg space-y-6">
                            <div class="flex flex-wrap items-center gap-4">
                                <Badge size="sm" text="Small" />
                                <Badge size="md" text="Medium" />
                                <Badge size="lg" text="Large" />
                            </div>
                            <div class="bg-muted/40 p-4 rounded-md">
                                <code class="text-sm text-gray-300">
                                    &lt;Badge size="sm" text="Small" /&gt;
                                    <br />
                                    &lt;Badge size="md" text="Medium" /&gt;
                                    <br />
                                    &lt;Badge size="lg" text="Large" /&gt;
                                </code>
                            </div>
                        </div>
                    </div>

                    <!-- Badge Features Section -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Özellikler</h3>
                        <div class="p-6 border border-border rounded-lg space-y-6">
                            <div class="flex flex-wrap gap-4">
                                <Badge variant="primary" text="Kapatılabilir" dismissible />
                                <Badge variant="success">
                                    <template #default>
                                        <span class="flex items-center">
                                            <svg class="w-3 h-3 mr-1" viewBox="0 0 20 20" fill="currentColor">
                                                <path fill-rule="evenodd" d="M10 18a8 8 0 100-16 8 8 0 000 16zm3.707-9.293a1 1 0 00-1.414-1.414L9 10.586 7.707 9.293a1 1 0 00-1.414 1.414l2 2a1 1 0 001.414 0l4-4z" clip-rule="evenodd" />
                                            </svg>
                                            Özel İçerik
                                        </span>
                                    </template>
                                </Badge>
                            </div>
                            <div class="bg-muted/40 p-4 rounded-md">
                                <code class="text-sm text-gray-300">
                                    &lt;Badge variant="primary" text="Kapatılabilir" dismissible /&gt;
                                    <br />
                                    &lt;Badge variant="success"&gt;
                                    <br />
                                    &nbsp;&nbsp;&lt;template #default&gt;
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;Özel İçerik
                                    <br />
                                    &nbsp;&nbsp;&lt;/template&gt;
                                    <br />
                                    &lt;/Badge&gt;
                                </code>
                            </div>
                        </div>
                    </div>
                </section>

                <!-- Table Documentation -->
                <section id="table" class="space-y-8 mt-16">
                    <div class="border-b border-border pb-4">
                        <h2 class="text-2xl font-bold text-white">Table</h2>
                        <p class="text-gray-400 mt-2">Veri gösterimi için kullanılan tablo bileşenleri.</p>
                    </div>

                    <!-- Import Section -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Import</h3>
                        <div class="border border-border p-4 rounded-md">
                            <code class="text-sm text-gray-300">
                                import Table from '@/components/ui/Table.vue'
                                <br />
                                import TableHeader from '@/components/ui/TableHeader.vue'
                                <br />
                                import TableHeaderCell from '@/components/ui/TableHeaderCell.vue'
                                <br />
                                import TableBody from '@/components/ui/TableBody.vue'
                                <br />
                                import TableRow from '@/components/ui/TableRow.vue'
                                <br />
                                import TableCell from '@/components/ui/TableCell.vue'
                            </code>
                        </div>
                    </div>

                    <!-- Basic Table -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Temel Tablo</h3>
                        <div class="p-6 border border-border rounded-lg space-y-6">
                            <Table>
                                <TableHeader>
                                    <TableRow>
                                        <TableHeaderCell>Name</TableHeaderCell>
                                        <TableHeaderCell>Email</TableHeaderCell>
                                        <TableHeaderCell>Role</TableHeaderCell>
                                        <TableHeaderCell>Status</TableHeaderCell>
                                    </TableRow>
                                </TableHeader>
                                <TableBody :items="sortedUsers">
                                    <template #row="item">
                                        <TableRow :item="item">
                                            <TableCell>item.name</TableCell>
                                            <TableCell>item.email</TableCell>
                                            <TableCell>item.role</TableCell>
                                            <TableCell>item.status</TableCell>
                                        </TableRow>
                                    </template>
                                </TableBody>
                            </Table>
                            <div class="bg-muted/40 p-4 rounded-md">
                                <code class="text-sm text-gray-300">
                                    &lt;Table&gt;
                                    <br />
                                    &nbsp;&nbsp;&lt;TableHeader&gt;
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&lt;TableRow&gt;
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;TableHeaderCell&gt;Name&lt;/TableHeaderCell&gt;
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;TableHeaderCell&gt;Email&lt;/TableHeaderCell&gt;
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;TableHeaderCell&gt;Role&lt;/TableHeaderCell&gt;
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;TableHeaderCell&gt;Status&lt;/TableHeaderCell&gt;
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&lt;/TableRow&gt;
                                    <br />
                                    &nbsp;&nbsp;&lt;/TableHeader&gt;
                                    <br />
                                    &nbsp;&nbsp;&lt;TableBody&gt;
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&lt;template v-for="item in sortedUsers" :key="item.id"&gt;
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;TableRow :item="item"&gt;
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;TableCell&gt;item.name&lt;/TableCell&gt;
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;TableCell&gt;item.email&lt;/TableCell&gt;
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;TableCell&gt;item.role&lt;/TableCell&gt;
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;TableCell&gt;item.status&lt;/TableCell&gt;
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/TableRow&gt;
                                    <br />
                                    &nbsp;&nbsp;&lt;/template&gt;
                                    <br />
                                    &nbsp;&nbsp;&lt;/TableBody&gt;
                                    <br />
                                    &lt;/Table&gt;
                                </code>
                            </div>
                        </div>
                    </div>

                    <!-- Sortable Table -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Sıralanabilir Tablo</h3>
                        <div class="p-6 border border-border rounded-lg space-y-6">
                            <Table>
                                <TableHeader>
                                    <TableRow>
                                        <TableHeaderCell sortable @sort="handleSort('name')">Name</TableHeaderCell>
                                        <TableHeaderCell sortable @sort="handleSort('email')">Email</TableHeaderCell>
                                        <TableHeaderCell sortable @sort="handleSort('role')">Role</TableHeaderCell>
                                        <TableHeaderCell sortable @sort="handleSort('status')">Status</TableHeaderCell>
                                    </TableRow>
                                </TableHeader>
                                <TableBody :items="sortedUsers">
                                    <template #row="{ item }">
                                        <TableRow :item="item">
                                            <TableCell>{{ item.name }}</TableCell>
                                            <TableCell>{{ item.email }}</TableCell>
                                            <TableCell>{{ item.role }}</TableCell>
                                            <TableCell>{{ item.status }}</TableCell>
                                        </TableRow>
                                    </template>
                                </TableBody>
                            </Table>
                            <div class="bg-muted/40 p-4 rounded-md">
                                <code class="text-sm text-gray-300">
                                    &lt;Table&gt;
                                    <br />
                                    &nbsp;&nbsp;&lt;TableHeader&gt;
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&lt;TableRow&gt;
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;TableHeaderCell
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sortable
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@sort="handleSort('name')"
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;/&gt;
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;TableHeaderCell
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sortable
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@sort="handleSort('email')"
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;/&gt;
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;TableHeaderCell
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sortable
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@sort="handleSort('role')"
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;/&gt;
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;TableHeaderCell
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sortable
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@sort="handleSort('status')"
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;/&gt;
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&lt;/TableRow&gt;
                                    <br />
                                    &nbsp;&nbsp;&lt;/TableHeader&gt;
                                    <br />
                                    &nbsp;&nbsp;&lt;TableBody&gt;
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&lt;template v-for="item in sortedUsers" :key="item.id"&gt;
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;TableRow :item="item"&gt;
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;TableCell&gt;item.name&lt;/TableCell&gt;
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;TableCell&gt;item.email&lt;/TableCell&gt;
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;TableCell&gt;item.role&lt;/TableCell&gt;
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;TableCell&gt;item.status&lt;/TableCell&gt;
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/TableRow&gt;
                                    <br />
                                    &nbsp;&nbsp;&lt;/template&gt;
                                    <br />
                                    &nbsp;&nbsp;&lt;/TableBody&gt;
                                    <br />
                                    &lt;/Table&gt;
                                </code>
                            </div>
                        </div>
                    </div>

                    <!-- Selectable Table -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Seçilebilir Tablo</h3>
                        <div class="p-6 border border-border rounded-lg space-y-6">
                            <Table>
                                <TableHeader>
                                    <TableRow>
                                        <TableHeaderCell>
                                            <Checkbox :model-value="selectedUsers.length === users.length" @update:model-value="toggleSelectAll" />
                                        </TableHeaderCell>
                                        <TableHeaderCell>Name</TableHeaderCell>
                                        <TableHeaderCell>Email</TableHeaderCell>
                                        <TableHeaderCell>Role</TableHeaderCell>
                                        <TableHeaderCell>Status</TableHeaderCell>
                                    </TableRow>
                                </TableHeader>
                                <TableBody :items="sortedUsers">
                                    <template #row="{ item }">
                                        <TableRow :item="item">
                                            <TableCell>
                                                <Checkbox :model-value="selectedUsers.some((u: TableData) => u.id === (item as TableData).id)" @update:model-value="toggleSelectUser(item as TableData)" />
                                            </TableCell>
                                            <TableCell>{{ item.name }}</TableCell>
                                            <TableCell>{{ item.email }}</TableCell>
                                            <TableCell>{{ item.role }}</TableCell>
                                            <TableCell>{{ item.status }}</TableCell>
                                        </TableRow>
                                    </template>
                                </TableBody>
                            </Table>
                            <div class="bg-muted/40 p-4 rounded-md">
                                <code class="text-sm text-gray-300">
                                    &lt;Table&gt;
                                    <br />
                                    &nbsp;&nbsp;&lt;TableHeader&gt;
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&lt;TableRow&gt;
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;TableHeaderCell&gt;
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Checkbox
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;v-model="selectAll"
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@change="toggleSelectAll"
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;/&gt;
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&lt;/TableRow&gt;
                                    <br />
                                    &nbsp;&nbsp;&lt;/TableHeader&gt;
                                    <br />
                                    &nbsp;&nbsp;&lt;TableBody&gt;
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&lt;template v-for="item in sortedUsers" :key="item.id"&gt;
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;TableRow :item="item"&gt;
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;TableCell&gt;
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Checkbox
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:model-value="selectedUsers.value.some((u: TableData) => u.id === (item as TableData).id)"
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@update:model-value="toggleSelectUser(item as TableData)"
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;/&gt;
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/TableCell&gt;
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;TableCell&gt;item.name&lt;/TableCell&gt;
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;TableCell&gt;item.email&lt;/TableCell&gt;
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;TableCell&gt;item.role&lt;/TableCell&gt;
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;TableCell&gt;item.status&lt;/TableCell&gt;
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/TableRow&gt;
                                    <br />
                                    &nbsp;&nbsp;&lt;/template&gt;
                                    <br />
                                    &nbsp;&nbsp;&lt;/TableBody&gt;
                                    <br />
                                    &lt;/Table&gt;
                                </code>
                            </div>
                        </div>
                    </div>
                </section>

                <!-- Checkbox Documentation -->
                <section id="checkbox" class="space-y-8 mt-16">
                    <div class="border-b border-border pb-4">
                        <h2 class="text-2xl font-bold text-white">Checkbox</h2>
                        <p class="text-gray-400 mt-2">Çoklu seçim yapmak için kullanılan checkbox bileşeni.</p>
                    </div>

                    <!-- Import Section -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Import</h3>
                        <div class="border border-border p-4 rounded-md">
                            <code class="text-sm text-gray-300">import Checkbox from '@/components/ui/Checkbox.vue'</code>
                        </div>
                    </div>

                    <!-- Basic Usage -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Temel Kullanım</h3>
                        <div class="p-6 border border-border rounded-lg space-y-6">
                            <div class="space-y-4">
                                <Checkbox v-model="checkboxValue1" label="Checkbox 1" />
                                <Checkbox v-model="checkboxValue2" label="Checkbox 2" />
                                <Checkbox v-model="checkboxValue3" label="Checkbox 3" />
                            </div>
                            <div class="bg-muted/40 p-4 rounded-md">
                                <code class="text-sm text-gray-300">
                                    &lt;Checkbox v-model="checkboxValue1" label="Checkbox 1" /&gt;
                                    <br />
                                    &lt;Checkbox v-model="checkboxValue2" label="Checkbox 2" /&gt;
                                    <br />
                                    &lt;Checkbox v-model="checkboxValue3" label="Checkbox 3" /&gt;
                                </code>
                            </div>
                        </div>
                    </div>

                    <!-- Inline Checkboxes -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Yan Yana Checkbox</h3>
                        <div class="p-6 border border-border rounded-lg space-y-6">
                            <div class="space-x-6">
                                <Checkbox v-model="inlineCheckbox1" label="Checkbox 1" inline />
                                <Checkbox v-model="inlineCheckbox2" label="Checkbox 2" inline />
                                <Checkbox v-model="inlineCheckbox3" label="Checkbox 3" inline />
                            </div>
                            <div class="bg-muted/40 p-4 rounded-md">
                                <code class="text-sm text-gray-300">
                                    &lt;Checkbox v-model="inlineCheckbox1" label="Checkbox 1" inline /&gt;
                                    <br />
                                    &lt;Checkbox v-model="inlineCheckbox2" label="Checkbox 2" inline /&gt;
                                    <br />
                                    &lt;Checkbox v-model="inlineCheckbox3" label="Checkbox 3" inline /&gt;
                                </code>
                            </div>
                        </div>
                    </div>

                    <!-- Checkbox States -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Durumlar</h3>
                        <div class="p-6 border border-border rounded-lg space-y-6">
                            <div class="space-y-4">
                                <Checkbox v-model="stateCheckbox1" label="Normal" />
                                <Checkbox v-model="stateCheckbox2" label="Checked" />
                                <Checkbox v-model="stateCheckbox3" label="Disabled" disabled />
                            </div>
                            <div class="bg-muted/40 p-4 rounded-md">
                                <code class="text-sm text-gray-300">
                                    &lt;Checkbox v-model="stateCheckbox1" label="Normal" /&gt;
                                    <br />
                                    &lt;Checkbox v-model="stateCheckbox2" label="Checked" /&gt;
                                    <br />
                                    &lt;Checkbox v-model="stateCheckbox3" label="Disabled" disabled /&gt;
                                </code>
                            </div>
                        </div>
                    </div>
                </section>

                <!-- Radio Documentation -->
                <section id="radio" class="space-y-8 mt-16">
                    <div class="border-b border-border pb-4">
                        <h2 class="text-2xl font-bold text-white">Radio</h2>
                        <p class="text-gray-400 mt-2">Tekli seçim yapmak için kullanılan radio bileşeni.</p>
                    </div>

                    <!-- Import Section -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Import</h3>
                        <div class="border border-border p-4 rounded-md">
                            <code class="text-sm text-gray-300">import Radio from '@/components/ui/Radio.vue'</code>
                        </div>
                    </div>

                    <!-- Basic Usage -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Temel Kullanım</h3>
                        <div class="p-6 border border-border rounded-lg space-y-6">
                            <div class="space-y-4">
                                <Radio v-model="radioValue" value="1" label="Radio 1" name="radio-demo" />
                                <Radio v-model="radioValue" value="2" label="Radio 2" name="radio-demo" />
                                <Radio v-model="radioValue" value="3" label="Radio 3" name="radio-demo" />
                            </div>
                            <div class="bg-muted/40 p-4 rounded-md">
                                <code class="text-sm text-gray-300">
                                    &lt;Radio v-model="radioValue" value="1" label="Radio 1" name="radio-demo" /&gt;
                                    <br />
                                    &lt;Radio v-model="radioValue" value="2" label="Radio 2" name="radio-demo" /&gt;
                                    <br />
                                    &lt;Radio v-model="radioValue" value="3" label="Radio 3" name="radio-demo" /&gt;
                                </code>
                            </div>
                        </div>
                    </div>

                    <!-- Inline -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Yan Yana Radio</h3>
                        <div class="p-6 border border-border rounded-lg space-y-6">
                            <div class="space-x-6">
                                <Radio v-model="inlineRadioValue" value="1" label="Radio 1" name="inline-radio-demo" inline />
                                <Radio v-model="inlineRadioValue" value="2" label="Radio 2" name="inline-radio-demo" inline />
                                <Radio v-model="inlineRadioValue" value="3" label="Radio 3" name="inline-radio-demo" inline />
                            </div>
                            <div class="bg-muted/40 p-4 rounded-md">
                                <code class="text-sm text-gray-300">
                                    &lt;Radio v-model="inlineRadioValue" value="1" label="Radio 1" name="inline-radio-demo" inline /&gt;
                                    <br />
                                    &lt;Radio v-model="inlineRadioValue" value="2" label="Radio 2" name="inline-radio-demo" inline /&gt;
                                    <br />
                                    &lt;Radio v-model="inlineRadioValue" value="3" label="Radio 3" name="inline-radio-demo" inline /&gt;
                                </code>
                            </div>
                        </div>
                    </div>

                    <!-- States -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Durumlar</h3>
                        <div class="p-6 border border-border rounded-lg space-y-6">
                            <div class="space-y-4">
                                <Radio v-model="stateRadioValue" value="1" label="Normal" name="state-radio-demo" />
                                <Radio v-model="stateRadioValue" value="2" label="Selected" name="state-radio-demo" />
                                <Radio v-model="stateRadioValue" value="3" label="Disabled" name="state-radio-demo" disabled />
                            </div>
                            <div class="bg-muted/40 p-4 rounded-md">
                                <code class="text-sm text-gray-300">
                                    &lt;Radio v-model="stateRadioValue" value="1" label="Normal" name="state-radio-demo" /&gt;
                                    <br />
                                    &lt;Radio v-model="stateRadioValue" value="2" label="Selected" name="state-radio-demo" /&gt;
                                    <br />
                                    &lt;Radio v-model="stateRadioValue" value="3" label="Disabled" name="state-radio-demo" disabled /&gt;
                                </code>
                            </div>
                        </div>
                    </div>
                </section>

                <!-- Textarea Documentation -->
                <section id="textarea" class="space-y-8 mt-16">
                    <div class="border-b border-border pb-4">
                        <h2 class="text-2xl font-bold text-white">Textarea</h2>
                        <p class="text-gray-400 mt-2">Çok satırlı metin girişi için kullanılan textarea bileşeni.</p>
                    </div>

                    <!-- Import Section -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Import</h3>
                        <div class="border border-border p-4 rounded-md">
                            <code class="text-sm text-gray-300">import Textarea from '@/components/ui/Textarea.vue'</code>
                        </div>
                    </div>

                    <!-- Props Section -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Props</h3>
                        <div class="overflow-x-auto">
                            <table class="min-w-full divide-y divide-border">
                                <thead>
                                    <tr>
                                        <th scope="col" class="py-3.5 pl-4 pr-3 text-left text-sm font-semibold text-white">Prop</th>
                                        <th scope="col" class="px-3 py-3.5 text-left text-sm font-semibold text-white">Type</th>
                                        <th scope="col" class="px-3 py-3.5 text-left text-sm font-semibold text-white">Default</th>
                                        <th scope="col" class="px-3 py-3.5 text-left text-sm font-semibold text-white">Description</th>
                                    </tr>
                                </thead>
                                <tbody class="divide-y divide-border">
                                    <tr>
                                        <td class="whitespace-nowrap py-4 pl-4 pr-3 text-sm font-medium text-white">modelValue</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">String</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">''</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">Textarea değeri</td>
                                    </tr>
                                    <tr>
                                        <td class="whitespace-nowrap py-4 pl-4 pr-3 text-sm font-medium text-white">rows</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">Number</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">4</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">Satır sayısı</td>
                                    </tr>
                                    <tr>
                                        <td class="whitespace-nowrap py-4 pl-4 pr-3 text-sm font-medium text-white">variant</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">String</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">'default'</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">Textarea varyantı (default, filled, outline, ghost)</td>
                                    </tr>
                                    <tr>
                                        <td class="whitespace-nowrap py-4 pl-4 pr-3 text-sm font-medium text-white">size</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">String</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">'md'</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">Textarea boyutu (sm, md, lg)</td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>

                    <!-- Textarea Variants Section -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Varyantlar</h3>
                        <div class="p-6 border border-border rounded-lg space-y-6">
                            <div class="max-w-sm space-y-4">
                                <Textarea variant="default" placeholder="Default variant" />
                                <Textarea variant="filled" placeholder="Filled variant" />
                                <Textarea variant="outline" placeholder="Outline variant" />
                                <Textarea variant="ghost" placeholder="Ghost variant" />
                            </div>
                            <div class="bg-muted/40 p-4 rounded-md">
                                <code class="text-sm text-gray-300">
                                    &lt;Textarea variant="default" placeholder="Default variant" /&gt;
                                    <br />
                                    &lt;Textarea variant="filled" placeholder="Filled variant" /&gt;
                                    <br />
                                    &lt;Textarea variant="outline" placeholder="Outline variant" /&gt;
                                    <br />
                                    &lt;Textarea variant="ghost" placeholder="Ghost variant" /&gt;
                                </code>
                            </div>
                        </div>
                    </div>

                    <!-- Textarea Sizes Section -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Boyutlar</h3>
                        <div class="p-6 border border-border rounded-lg space-y-6">
                            <div class="max-w-sm space-y-4">
                                <Textarea size="sm" placeholder="Small textarea" />
                                <Textarea size="md" placeholder="Medium textarea" />
                                <Textarea size="lg" placeholder="Large textarea" />
                            </div>
                            <div class="bg-muted/40 p-4 rounded-md">
                                <code class="text-sm text-gray-300">
                                    &lt;Textarea size="sm" placeholder="Small textarea" /&gt;
                                    <br />
                                    &lt;Textarea size="md" placeholder="Medium textarea" /&gt;
                                    <br />
                                    &lt;Textarea size="lg" placeholder="Large textarea" /&gt;
                                </code>
                            </div>
                        </div>
                    </div>

                    <!-- Textarea States Section -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Durumlar</h3>
                        <div class="p-6 border border-border rounded-lg space-y-6">
                            <div class="max-w-sm space-y-4">
                                <Textarea label="Normal" placeholder="Normal textarea" />
                                <Textarea label="Disabled" placeholder="Disabled textarea" disabled />
                                <Textarea label="With Error" placeholder="Error textarea" error="Bu alan zorunludur" />
                                <Textarea label="With Helper" placeholder="Helper text" helperText="Bu alana açıklama yazınız" />
                            </div>
                            <div class="bg-muted/40 p-4 rounded-md">
                                <code class="text-sm text-gray-300">
                                    &lt;Textarea label="Normal" placeholder="Normal textarea" /&gt;
                                    <br />
                                    &lt;Textarea label="Disabled" placeholder="Disabled textarea" disabled /&gt;
                                    <br />
                                    &lt;Textarea label="With Error" placeholder="Error textarea" error="Bu alan zorunludur" /&gt;
                                    <br />
                                    &lt;Textarea label="With Helper" placeholder="Helper text" helperText="Bu alana açıklama yazınız" /&gt;
                                </code>
                            </div>
                        </div>
                    </div>
                </section>

                <!-- Date Picker Documentation -->
                <section id="datepicker" class="space-y-8 mt-16">
                    <div class="border-b border-border pb-4">
                        <h2 class="text-2xl font-bold text-white">Date Picker</h2>
                        <p class="text-gray-400 mt-2">Tarih seçimi için kullanılan date picker bileşeni.</p>
                    </div>

                    <!-- Import Section -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Import</h3>
                        <div class="border border-border p-4 rounded-md">
                            <code class="text-sm text-gray-300">import DatePicker from '@/components/ui/DatePicker.vue'</code>
                        </div>
                    </div>

                    <!-- Props Section -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Props</h3>
                        <div class="overflow-x-auto">
                            <table class="min-w-full divide-y divide-border">
                                <thead>
                                    <tr>
                                        <th scope="col" class="py-3.5 pl-4 pr-3 text-left text-sm font-semibold text-white">Prop</th>
                                        <th scope="col" class="px-3 py-3.5 text-left text-sm font-semibold text-white">Type</th>
                                        <th scope="col" class="px-3 py-3.5 text-left text-sm font-semibold text-white">Default</th>
                                        <th scope="col" class="px-3 py-3.5 text-left text-sm font-semibold text-white">Description</th>
                                    </tr>
                                </thead>
                                <tbody class="divide-y divide-border">
                                    <tr>
                                        <td class="whitespace-nowrap py-4 pl-4 pr-3 text-sm font-medium text-white">modelValue</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">String</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">''</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">Seçilen tarih değeri (YYYY-MM-DD)</td>
                                    </tr>
                                    <tr>
                                        <td class="whitespace-nowrap py-4 pl-4 pr-3 text-sm font-medium text-white">min</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">String</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">undefined</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">Minimum seçilebilir tarih</td>
                                    </tr>
                                    <tr>
                                        <td class="whitespace-nowrap py-4 pl-4 pr-3 text-sm font-medium text-white">max</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">String</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">undefined</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">Maksimum seçilebilir tarih</td>
                                    </tr>
                                    <tr>
                                        <td class="whitespace-nowrap py-4 pl-4 pr-3 text-sm font-medium text-white">variant</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">String</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">'default'</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">Date picker varyantı (default, filled, outline, ghost)</td>
                                    </tr>
                                    <tr>
                                        <td class="whitespace-nowrap py-4 pl-4 pr-3 text-sm font-medium text-white">size</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">String</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">'md'</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">Date picker boyutu (sm, md, lg)</td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>

                    <!-- Date Picker Variants Section -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Varyantlar</h3>
                        <div class="p-6 border border-border rounded-lg space-y-6">
                            <div class="max-w-sm space-y-4">
                                <DatePicker variant="default" label="Default variant" />
                                <DatePicker variant="filled" label="Filled variant" />
                                <DatePicker variant="outline" label="Outline variant" />
                                <DatePicker variant="ghost" label="Ghost variant" />
                            </div>
                            <div class="bg-muted/40 p-4 rounded-md">
                                <code class="text-sm text-gray-300">
                                    &lt;DatePicker variant="default" label="Default variant" /&gt;
                                    <br />
                                    &lt;DatePicker variant="filled" label="Filled variant" /&gt;
                                    <br />
                                    &lt;DatePicker variant="outline" label="Outline variant" /&gt;
                                    <br />
                                    &lt;DatePicker variant="ghost" label="Ghost variant" /&gt;
                                </code>
                            </div>
                        </div>
                    </div>

                    <!-- Date Picker Sizes Section -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Boyutlar</h3>
                        <div class="p-6 border border-border rounded-lg space-y-6">
                            <div class="max-w-sm space-y-4">
                                <DatePicker size="sm" label="Small date picker" />
                                <DatePicker size="md" label="Medium date picker" />
                                <DatePicker size="lg" label="Large date picker" />
                            </div>
                            <div class="bg-muted/40 p-4 rounded-md">
                                <code class="text-sm text-gray-300">
                                    &lt;DatePicker size="sm" label="Small date picker" /&gt;
                                    <br />
                                    &lt;DatePicker size="md" label="Medium date picker" /&gt;
                                    <br />
                                    &lt;DatePicker size="lg" label="Large date picker" /&gt;
                                </code>
                            </div>
                        </div>
                    </div>

                    <!-- Date Picker States Section -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Durumlar</h3>
                        <div class="p-6 border border-border rounded-lg space-y-6">
                            <div class="max-w-sm space-y-4">
                                <DatePicker label="Normal" v-model="dateValue1" />
                                <DatePicker label="With Min/Max" v-model="dateValue2" min="2024-01-01" max="2024-12-31" />
                                <DatePicker label="Disabled" v-model="dateValue3" disabled />
                                <DatePicker label="With Error" v-model="dateValue4" error="Lütfen bir tarih seçin" />
                                <DatePicker label="With Helper" v-model="dateValue5" helperText="YYYY-AA-GG formatında bir tarih seçin" />
                            </div>
                            <div class="bg-muted/40 p-4 rounded-md">
                                <code class="text-sm text-gray-300">
                                    &lt;DatePicker
                                    <br />
                                    &nbsp;&nbsp;label="Normal"
                                    <br />
                                    &nbsp;&nbsp;v-model="dateValue"
                                    <br />
                                    /&gt;
                                    <br />
                                    <br />
                                    &lt;DatePicker
                                    <br />
                                    &nbsp;&nbsp;label="With Min/Max"
                                    <br />
                                    &nbsp;&nbsp;v-model="dateValue"
                                    <br />
                                    &nbsp;&nbsp;min="2024-01-01"
                                    <br />
                                    &nbsp;&nbsp;max="2024-12-31"
                                    <br />
                                    /&gt;
                                    <br />
                                    <br />
                                    &lt;DatePicker
                                    <br />
                                    &nbsp;&nbsp;label="Disabled"
                                    <br />
                                    &nbsp;&nbsp;v-model="dateValue"
                                    <br />
                                    &nbsp;&nbsp;disabled
                                    <br />
                                    /&gt;
                                </code>
                            </div>
                        </div>
                    </div>
                </section>

                <!-- File Upload Documentation -->
                <section id="fileupload" class="space-y-8 mt-16">
                    <div class="border-b border-border pb-4">
                        <h2 class="text-2xl font-bold text-white">File Upload</h2>
                        <p class="text-gray-400 mt-2">Dosya yükleme işlemleri için kullanılan bileşen.</p>
                    </div>

                    <!-- Import Section -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Import</h3>
                        <div class="border border-border p-4 rounded-md">
                            <code class="text-sm text-gray-300">import FileUpload from '@/components/ui/FileUpload.vue'</code>
                        </div>
                    </div>

                    <!-- Props Section -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Props</h3>
                        <div class="overflow-x-auto">
                            <table class="min-w-full divide-y divide-border">
                                <thead>
                                    <tr>
                                        <th scope="col" class="py-3.5 pl-4 pr-3 text-left text-sm font-semibold text-white">Prop</th>
                                        <th scope="col" class="px-3 py-3.5 text-left text-sm font-semibold text-white">Type</th>
                                        <th scope="col" class="px-3 py-3.5 text-left text-sm font-semibold text-white">Default</th>
                                        <th scope="col" class="px-3 py-3.5 text-left text-sm font-semibold text-white">Description</th>
                                    </tr>
                                </thead>
                                <tbody class="divide-y divide-border">
                                    <tr>
                                        <td class="whitespace-nowrap py-4 pl-4 pr-3 text-sm font-medium text-white">modelValue</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">File[]</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">[]</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">Seçilen dosyalar</td>
                                    </tr>
                                    <tr>
                                        <td class="whitespace-nowrap py-4 pl-4 pr-3 text-sm font-medium text-white">accept</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">String</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">'*/*'</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">Kabul edilen dosya tipleri</td>
                                    </tr>
                                    <tr>
                                        <td class="whitespace-nowrap py-4 pl-4 pr-3 text-sm font-medium text-white">multiple</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">Boolean</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">false</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">Çoklu dosya seçimi</td>
                                    </tr>
                                    <tr>
                                        <td class="whitespace-nowrap py-4 pl-4 pr-3 text-sm font-medium text-white">maxSize</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">Number</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">5</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">Maksimum dosya boyutu (MB)</td>
                                    </tr>
                                    <tr>
                                        <td class="whitespace-nowrap py-4 pl-4 pr-3 text-sm font-medium text-white">variant</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">String</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">'default'</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">Upload varyantı (default, filled, outline, ghost)</td>
                                    </tr>
                                    <tr>
                                        <td class="whitespace-nowrap py-4 pl-4 pr-3 text-sm font-medium text-white">size</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">String</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">'md'</td>
                                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">Upload boyutu (sm, md, lg)</td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>

                    <!-- File Upload Variants Section -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Varyantlar</h3>
                        <div class="p-6 border border-border rounded-lg space-y-6">
                            <div class="max-w-sm space-y-4">
                                <FileUpload v-model="files1" variant="default" label="Default variant" />
                                <FileUpload v-model="files2" variant="filled" label="Filled variant" />
                                <FileUpload v-model="files3" variant="outline" label="Outline variant" />
                                <FileUpload v-model="files4" variant="ghost" label="Ghost variant" />
                            </div>
                            <div class="bg-muted/40 p-4 rounded-md">
                                <code class="text-sm text-gray-300">
                                    &lt;FileUpload variant="default" label="Default variant" /&gt;
                                    <br />
                                    &lt;FileUpload variant="filled" label="Filled variant" /&gt;
                                    <br />
                                    &lt;FileUpload variant="outline" label="Outline variant" /&gt;
                                    <br />
                                    &lt;FileUpload variant="ghost" label="Ghost variant" /&gt;
                                </code>
                            </div>
                        </div>
                    </div>

                    <!-- File Upload Sizes Section -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Boyutlar</h3>
                        <div class="p-6 border border-border rounded-lg space-y-6">
                            <div class="max-w-sm space-y-4">
                                <FileUpload v-model="files1" size="sm" label="Small file upload" />
                                <FileUpload v-model="files2" size="md" label="Medium file upload" />
                                <FileUpload v-model="files3" size="lg" label="Large file upload" />
                            </div>
                            <div class="bg-muted/40 p-4 rounded-md">
                                <code class="text-sm text-gray-300">
                                    &lt;FileUpload size="sm" label="Small file upload" /&gt;
                                    <br />
                                    &lt;FileUpload size="md" label="Medium file upload" /&gt;
                                    <br />
                                    &lt;FileUpload size="lg" label="Large file upload" /&gt;
                                </code>
                            </div>
                        </div>
                    </div>

                    <!-- File Upload Features Section -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Özellikler</h3>
                        <div class="p-6 border border-border rounded-lg space-y-6">
                            <div class="max-w-sm space-y-4">
                                <!-- Basic Upload -->
                                <FileUpload v-model="files1" label="Temel Kullanım" />

                                <!-- Multiple Files -->
                                <FileUpload v-model="files2" label="Çoklu Dosya" multiple />

                                <!-- With Accept -->
                                <FileUpload v-model="files3" label="Sadece Resim" accept="image/*" />

                                <!-- With Progress -->
                                <FileUpload v-model="files4" label="Yükleme Durumu" :progress="uploadProgress" />

                                <!-- With Error -->
                                <FileUpload v-model="files5" label="Hata Durumu" error="Dosya yüklenirken bir hata oluştu" />
                            </div>
                            <div class="bg-muted/40 p-4 rounded-md">
                                <code class="text-sm text-gray-300">
                                    &lt;!-- Temel Kullanım --&gt;
                                    <br />
                                    &lt;FileUpload v-model="files" label="Temel Kullanım" /&gt;
                                    <br />
                                    <br />
                                    &lt;!-- Çoklu Dosya --&gt;
                                    <br />
                                    &lt;FileUpload
                                    <br />
                                    &nbsp;&nbsp;v-model="files"
                                    <br />
                                    &nbsp;&nbsp;label="Çoklu Dosya"
                                    <br />
                                    &nbsp;&nbsp;multiple
                                    <br />
                                    /&gt;
                                    <br />
                                    <br />
                                    &lt;!-- Sadece Resim --&gt;
                                    <br />
                                    &lt;FileUpload
                                    <br />
                                    &nbsp;&nbsp;v-model="files"
                                    <br />
                                    &nbsp;&nbsp;label="Sadece Resim"
                                    <br />
                                    &nbsp;&nbsp;accept="image/*"
                                    <br />
                                    /&gt;
                                    <br />
                                    <br />
                                    &lt;!-- Yükleme Durumu --&gt;
                                    <br />
                                    &lt;FileUpload
                                    <br />
                                    &nbsp;&nbsp;v-model="files"
                                    <br />
                                    &nbsp;&nbsp;label="Yükleme Durumu"
                                    <br />
                                    &nbsp;&nbsp;:progress="70"
                                    <br />
                                    /&gt;
                                </code>
                            </div>
                        </div>
                    </div>
                </section>

                <!-- List Documentation -->
                <section id="list" class="space-y-8 mt-16">
                    <div class="border-b border-border pb-4">
                        <h2 class="text-2xl font-bold text-white">List</h2>
                        <p class="text-gray-400 mt-2">Liste görünümü için kullanılan list bileşeni.</p>
                    </div>

                    <!-- Import Section -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Import</h3>
                        <div class="border border-border p-4 rounded-md">
                            <code class="text-sm text-gray-300">
                                import List from '@/components/ui/List.vue'
                                <br />
                                import ListItem from '@/components/ui/ListItem.vue'
                            </code>
                        </div>
                    </div>

                    <!-- Basic Usage -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Temel Kullanım</h3>
                        <div class="p-6 border border-border rounded-lg space-y-6">
                            <List>
                                <ListItem v-for="item in listItems" :key="item.title" :title="item.title" :description="item.description" />
                            </List>
                            <div class="bg-muted/40 p-4 rounded-md">
                                <code class="text-sm text-gray-300">
                                    &lt;List&gt;
                                    <br />
                                    &nbsp;&nbsp;&lt;ListItem
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;v-for="item in listItems.value"
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;:key="item.title"
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;:title="item.title"
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;:description="item.description"
                                    <br />
                                    &nbsp;&nbsp;/&gt;
                                    <br />
                                    &lt;/List&gt;
                                </code>
                            </div>
                        </div>
                    </div>

                    <!-- Bordered List -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Kenarlıklı Liste</h3>
                        <div class="p-6 border border-border rounded-lg space-y-6">
                            <List bordered>
                                <ListItem v-for="item in listItems" :key="item.title" :title="item.title" :description="item.description" />
                            </List>
                            <div class="bg-muted/40 p-4 rounded-md">
                                <code class="text-sm text-gray-300">
                                    &lt;List bordered&gt;
                                    <br />
                                    &nbsp;&nbsp;&lt;ListItem
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;v-for="item in listItems.value"
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;:key="item.title"
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;:title="item.title"
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;:description="item.description"
                                    <br />
                                    &nbsp;&nbsp;/&gt;
                                    <br />
                                    &lt;/List&gt;
                                </code>
                            </div>
                        </div>
                    </div>

                    <!-- Clickable List -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Tıklanabilir Liste</h3>
                        <div class="p-6 border border-border rounded-lg space-y-6">
                            <List bordered>
                                <ListItem v-for="item in listItems" :key="item.title" :title="item.title" :description="item.description" clickable @click="() => handleListItemClick(item)" />
                            </List>
                            <div class="bg-muted/40 p-4 rounded-md">
                                <code class="text-sm text-gray-300">
                                    &lt;List bordered&gt;
                                    <br />
                                    &nbsp;&nbsp;&lt;ListItem
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;v-for="item in listItems.value"
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;:key="item.title"
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;:title="item.title"
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;:description="item.description"
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;clickable
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;@click="() => handleListItemClick(item)"
                                    <br />
                                    &nbsp;&nbsp;/&gt;
                                    <br />
                                    &lt;/List&gt;
                                </code>
                            </div>
                        </div>
                    </div>
                </section>

                <!-- Navigasyon Bileşenleri Documentation -->
                <div id="navigation-components" class="space-y-8 mt-16">
                    <div>
                        <h2 class="text-2xl font-bold text-white mb-4">Navigasyon Bileşenleri</h2>
                        <p class="text-zinc-400 mb-8">Sayfa içi gezinme ve yönlendirme için kullanılan bileşenler.</p>

                        <!-- Navbar -->
                        <div class="space-y-4 mb-8">
                            <h3 class="text-lg font-medium text-white">Navbar</h3>
                            <p class="text-zinc-400">Üst gezinme menüsü için kullanılan responsive bileşen.</p>

                            <div class="border border-zinc-800 rounded-lg p-4">
                                <Navbar>
                                    <template #brand>
                                        <span class="text-white font-bold">Logo</span>
                                    </template>
                                    <template #menu>
                                        <a href="#" class="text-zinc-400 hover:text-white px-3 py-2 rounded-md text-sm font-medium">Ana Sayfa</a>
                                        <a href="#" class="text-zinc-400 hover:text-white px-3 py-2 rounded-md text-sm font-medium">Ürünler</a>
                                        <a href="#" class="text-zinc-400 hover:text-white px-3 py-2 rounded-md text-sm font-medium">Hakkımızda</a>
                                    </template>
                                    <template #right>
                                        <Button variant="primary" size="sm">Giriş Yap</Button>
                                    </template>
                                </Navbar>
                            </div>
                        </div>

                        <!-- Sidebar -->
                        <div class="space-y-4 mb-8">
                            <h3 class="text-lg font-medium text-white">Sidebar</h3>
                            <p class="text-zinc-400">Yan gezinme menüsü için kullanılan daraltılabilir bileşen.</p>

                            <div class="border border-zinc-800 rounded-lg p-4 relative h-[400px]">
                                <Sidebar className="relative inset-auto w-64 h-full">
                                    <template #header>
                                        <span class="text-white font-bold">Menü</span>
                                    </template>
                                    <div class="p-4 space-y-2">
                                        <a href="#" class="flex items-center text-zinc-400 hover:text-white px-2 py-2 rounded-md text-sm">
                                            <svg class="w-5 h-5 mr-3" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                                                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M3 12l2-2m0 0l7-7 7 7M5 10v10a1 1 0 001 1h3m10-11l2 2m-2-2v10a1 1 0 01-1 1h-3m-6 0a1 1 0 001-1v-4a1 1 0 011-1h2a1 1 0 011 1v4a1 1 0 001 1m-6 0h6" />
                                            </svg>
                                            Ana Sayfa
                                        </a>
                                        <a href="#" class="flex items-center text-zinc-400 hover:text-white px-2 py-2 rounded-md text-sm">
                                            <svg class="w-5 h-5 mr-3" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                                                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M16 11V7a4 4 0 00-8 0v4M5 9h14l1 12H4L5 9z" />
                                            </svg>
                                            Ürünler
                                        </a>
                                        <a href="#" class="flex items-center text-zinc-400 hover:text-white px-2 py-2 rounded-md text-sm">
                                            <svg class="w-5 h-5 mr-3" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                                                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M16 7a4 4 0 11-8 0 4 4 0 018 0zM12 14a7 7 0 00-7 7h14a7 7 0 00-7-7z" />
                                            </svg>
                                            Profil
                                        </a>
                                    </div>
                                </Sidebar>
                            </div>
                        </div>

                        <!-- Breadcrumb -->
                        <div class="space-y-4 mb-8">
                            <h3 class="text-lg font-medium text-white">Breadcrumb</h3>
                            <p class="text-zinc-400">Sayfa hiyerarşisini gösteren gezinme bileşeni.</p>

                            <div class="border border-zinc-800 rounded-lg p-4">
                                <Breadcrumb>
                                    <BreadcrumbItem label="Ana Sayfa" to="#" first />
                                    <BreadcrumbItem label="Ürünler" to="#" />
                                    <BreadcrumbItem label="Elektronik" to="#" />
                                    <BreadcrumbItem label="Telefonlar" active />
                                </Breadcrumb>
                            </div>
                        </div>

                        <!-- Pagination -->
                        <div class="space-y-4">
                            <h3 class="text-lg font-medium text-white">Pagination</h3>
                            <p class="text-zinc-400">Sayfalama işlemleri için kullanılan bileşen.</p>

                            <div class="border border-zinc-800 rounded-lg p-4">
                                <Pagination v-model:currentPage="currentPage" :total-items="100" :per-page="10" />
                            </div>
                        </div>
                    </div>
                </div>

                <!-- Yardımcı Bileşenler Documentation -->
                <section id="helper-components" class="space-y-8 mt-16">
                    <div class="border-b border-border pb-4">
                        <h2 class="text-2xl font-bold text-white">Yardımcı Bileşenler</h2>
                        <p class="text-gray-400 mt-2">Kullanıcı deneyimini zenginleştiren yardımcı bileşenler.</p>
                    </div>

                    <!-- Tooltip -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Tooltip</h3>
                        <div class="p-6 border border-border rounded-lg space-y-6">
                            <div class="flex flex-wrap gap-4">
                                <Tooltip text="Üst Tooltip" position="top">
                                    <Button>Üstte</Button>
                                </Tooltip>
                                <Tooltip text="Sağ Tooltip" position="right">
                                    <Button>Sağda</Button>
                                </Tooltip>
                                <Tooltip text="Alt Tooltip" position="bottom">
                                    <Button>Altta</Button>
                                </Tooltip>
                                <Tooltip text="Sol Tooltip" position="left">
                                    <Button>Solda</Button>
                                </Tooltip>
                            </div>
                        </div>
                    </div>

                    <!-- Popover -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Popover</h3>
                        <div class="p-6 border border-border rounded-lg space-y-6">
                            <div class="flex flex-wrap gap-4">
                                <Popover>
                                    <template #trigger>
                                        <Button>Popover Aç</Button>
                                    </template>
                                    <div class="p-4">
                                        <h4 class="font-medium mb-2">Popover Başlık</h4>
                                        <p class="text-sm text-gray-400">Popover içeriği buraya gelecek.</p>
                                    </div>
                                </Popover>
                            </div>
                        </div>
                    </div>

                    <!-- Tag -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Tag</h3>
                        <div class="p-6 border border-border rounded-lg space-y-6">
                            <div class="flex flex-wrap gap-4">
                                <Tag text="Primary" />
                                <Tag text="Secondary" variant="secondary" />
                                <Tag text="Success" variant="success" />
                                <Tag text="Warning" variant="warning" />
                                <Tag text="Danger" variant="danger" />
                                <Tag text="Info" variant="info" />
                                <Tag text="Kapatılabilir" dismissible />
                            </div>
                        </div>
                    </div>

                    <!-- Avatar -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Avatar</h3>
                        <div class="p-6 border border-border rounded-lg space-y-6">
                            <div class="flex flex-wrap gap-4 items-center">
                                <Avatar src="https://i.pravatar.cc/300" alt="User Avatar" size="sm" />
                                <Avatar src="https://i.pravatar.cc/300" alt="User Avatar" size="md" />
                                <Avatar src="https://i.pravatar.cc/300" alt="User Avatar" size="lg" />
                                <Avatar src="https://i.pravatar.cc/300" alt="User Avatar" size="xl" />
                                <Avatar initials="JD" size="md" status="online" />
                            </div>
                        </div>
                    </div>

                    <!-- Rating -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Rating</h3>
                        <div class="p-6 border border-border rounded-lg space-y-6">
                            <div class="flex flex-wrap gap-8">
                                <Rating v-model="rating1" :max-stars="5" size="sm" />
                                <Rating v-model="rating2" :max-stars="5" size="md" />
                                <Rating v-model="rating3" :max-stars="5" size="lg" show-value />
                                <Rating v-model="rating4" :max-stars="5" readonly />
                            </div>
                        </div>
                    </div>

                    <!-- Image Gallery -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Image Gallery</h3>
                        <div class="p-6 border border-border rounded-lg space-y-6">
                            <ImageGallery
                                :images="[
                                    { src: 'https://picsum.photos/800/400?random=1', alt: 'Image 1' },
                                    { src: 'https://picsum.photos/800/400?random=2', alt: 'Image 2' },
                                    { src: 'https://picsum.photos/800/400?random=3', alt: 'Image 3' },
                                ]"
                                show-thumbnails
                                autoplay
                            />
                        </div>
                    </div>
                </section>

                <!-- Kart Bileşenleri Documentation -->
                <section id="card-components" class="space-y-8 mt-16">
                    <h2 class="text-2xl font-bold text-gray-900 dark:text-white">Kart Bileşenleri</h2>
                    <p class="text-gray-600 dark:text-zinc-300">Farklı amaçlar için tasarlanmış kart bileşenleri.</p>

                    <!-- Ürün Kartı -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-gray-900 dark:text-white">Ürün Kartı</h3>
                        <div class="grid gap-4 sm:grid-cols-2 lg:grid-cols-3">
                            <ProductCard
                                :product="{
                                    id: 1,
                                    name: 'Kablosuz Kulaklık',
                                    description: 'Aktif gürültü önleme özellikli premium kablosuz kulaklık',
                                    image: 'https://picsum.photos/400/300',
                                    price: 2499.99,
                                    originalPrice: 2999.99,
                                    discount: 15,
                                    stock: 25,
                                    isFavorite: false,
                                }"
                                @add-to-cart="() => {}"
                                @toggle-favorite="() => {}"
                            />
                            <ProductCard
                                :product="{
                                    id: 2,
                                    name: 'Akıllı Saat',
                                    description: 'Spor ve sağlık takibi için akıllı saat',
                                    image: 'https://picsum.photos/400/301',
                                    price: 1899.99,
                                    stock: 8,
                                    isFavorite: true,
                                }"
                                @add-to-cart="() => {}"
                                @toggle-favorite="() => {}"
                            />
                            <ProductCard
                                :product="{
                                    id: 3,
                                    name: 'Bluetooth Hoparlör',
                                    description: 'Su geçirmez taşınabilir bluetooth hoparlör',
                                    image: 'https://picsum.photos/400/302',
                                    price: 899.99,
                                    originalPrice: 1199.99,
                                    discount: 25,
                                    stock: 0,
                                    isFavorite: false,
                                }"
                                @add-to-cart="() => {}"
                                @toggle-favorite="() => {}"
                            />
                        </div>
                    </div>

                    <!-- Sipariş Kartı -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-gray-900 dark:text-white">Sipariş Kartı</h3>
                        <div class="grid gap-4 lg:grid-cols-2">
                            <OrderCard
                                :order="{
                                    id: 1001,
                                    date: '2024-02-15T10:30:00',
                                    status: 'completed',
                                    items: [
                                        {
                                            id: 1,
                                            name: 'Kablosuz Kulaklık',
                                            image: 'https://picsum.photos/400/300',
                                            price: 2499.99,
                                            quantity: 1,
                                        },
                                        {
                                            id: 2,
                                            name: 'Akıllı Saat',
                                            image: 'https://picsum.photos/400/301',
                                            price: 1899.99,
                                            quantity: 2,
                                        },
                                    ],
                                    subtotal: 6299.97,
                                    shipping: 29.99,
                                    total: 6329.96,
                                }"
                                @view-details="() => {}"
                            />
                            <OrderCard
                                :order="{
                                    id: 1002,
                                    date: '2024-02-14T15:45:00',
                                    status: 'processing',
                                    items: [
                                        {
                                            id: 3,
                                            name: 'Bluetooth Hoparlör',
                                            image: 'https://picsum.photos/400/302',
                                            price: 899.99,
                                            quantity: 1,
                                        },
                                    ],
                                    subtotal: 899.99,
                                    shipping: 29.99,
                                    total: 929.98,
                                }"
                                @view-details="() => {}"
                            />
                        </div>
                    </div>

                    <!-- İstatistik Kartları -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-gray-900 dark:text-white">İstatistik Kartları</h3>
                        <div class="grid gap-4 sm:grid-cols-2 lg:grid-cols-4">
                            <StatisticCard title="Toplam Satış" :value="125999.99" format="currency" variant="primary" :trend="12.5" subtitle="Geçen aya göre <span class='font-medium text-green-600 dark:text-green-400'>%12.5</span> artış">
                                <template #icon>
                                    <svg class="h-6 w-6" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                                        <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M12 8c-1.657 0-3 .895-3 2s1.343 2 3 2 3 .895 3 2-1.343 2-3 2m0-8c1.11 0 2.08.402 2.599 1M12 8V7m0 1v8m0 0v1m0-1c-1.11 0-2.08-.402-2.599-1M21 12a9 9 0 11-18 0 9 9 0 0118 0z" />
                                    </svg>
                                </template>
                            </StatisticCard>

                            <StatisticCard title="Yeni Müşteriler" :value="256" variant="success" :trend="8.2" subtitle="Bu ay 256 yeni müşteri kazanıldı">
                                <template #icon>
                                    <svg class="h-6 w-6" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                                        <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M17 20h5v-2a3 3 0 00-5.356-1.857M17 20H7m10 0v-2c0-.656-.126-1.283-.356-1.857M7 20H2v-2a3 3 0 015.356-1.857M7 20v-2c0-.656.126-1.283.356-1.857m0 0a5.002 5.002 0 019.288 0M15 7a3 3 0 11-6 0 3 3 0 016 0zm6 3a2 2 0 11-4 0 2 2 0 014 0zM7 10a2 2 0 11-4 0 2 2 0 014 0z" />
                                    </svg>
                                </template>
                            </StatisticCard>

                            <StatisticCard title="Dönüşüm Oranı" :value="15.7" format="percent" variant="warning" :trend="-2.3" subtitle="Geçen haftaya göre düşüş">
                                <template #icon>
                                    <svg class="h-6 w-6" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                                        <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 19v-6a2 2 0 00-2-2H5a2 2 0 00-2 2v6a2 2 0 002 2h2a2 2 0 002-2zm0 0V9a2 2 0 012-2h2a2 2 0 012 2v10m-6 0a2 2 0 002 2h2a2 2 0 002-2m0 0V5a2 2 0 012-2h2a2 2 0 012 2v14a2 2 0 01-2 2h-2a2 2 0 01-2-2z" />
                                    </svg>
                                </template>
                            </StatisticCard>

                            <StatisticCard title="İptal Edilen Siparişler" :value="12" variant="danger" :trend="5.4" subtitle="Son 24 saatte 12 iptal">
                                <template #icon>
                                    <svg class="h-6 w-6" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                                        <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M6 18L18 6M6 6l12 12" />
                                    </svg>
                                </template>
                            </StatisticCard>
                        </div>
                    </div>

                    <!-- Profil Kartı -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-gray-900 dark:text-white">Profil Kartı</h3>
                        <div class="grid gap-4 lg:grid-cols-2">
                            <ProfileCard
                                name="Ahmet Yılmaz"
                                title="Kıdemli Yazılım Geliştirici"
                                avatar="https://picsum.photos/200"
                                coverImage="https://picsum.photos/1000/300"
                                status="online"
                                bio="10+ yıl deneyimli full-stack geliştirici. Modern web teknolojileri ve mimari tasarım konularında uzman."
                                :stats="[
                                    { label: 'Projeler', value: 48 },
                                    { label: 'Takipçiler', value: 2150 },
                                    { label: 'Takip', value: 184 },
                                ]"
                                :contact="{
                                    email: 'ahmet.yilmaz@example.com',
                                    phone: '+90 555 123 4567',
                                    location: 'İstanbul, Türkiye',
                                }"
                            >
                                <template #actions>
                                    <button class="rounded-lg bg-blue-600 px-3 py-1 text-sm font-medium text-white transition hover:bg-blue-700">Takip Et</button>
                                </template>
                            </ProfileCard>

                            <ProfileCard
                                name="Ayşe Demir"
                                title="UI/UX Tasarımcısı"
                                avatar="https://picsum.photos/201"
                                status="busy"
                                bio="Kullanıcı deneyimi ve arayüz tasarımı konusunda 5 yıllık deneyim. Minimal ve kullanıcı dostu tasarımlar."
                                :stats="[
                                    { label: 'Tasarımlar', value: 124 },
                                    { label: 'Beğeniler', value: 8432 },
                                    { label: 'Yorumlar', value: 342 },
                                ]"
                                :contact="{
                                    email: 'ayse.demir@example.com',
                                    location: 'Ankara, Türkiye',
                                }"
                            />
                        </div>
                    </div>
                </section>

                <!-- Modal ve Dialog Bileşenleri Documentation -->
                <section id="modal-dialog-components" class="space-y-8 mt-16">
                    <div class="border-b border-border pb-4">
                        <h2 class="text-2xl font-bold text-gray-900 dark:text-white">Modal ve Dialog Bileşenleri</h2>
                        <p class="text-gray-600 dark:text-zinc-300 mt-2">Kullanıcı etkileşimleri için modal ve dialog bileşenleri.</p>
                    </div>

                    <!-- Temel Modal -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-gray-900 dark:text-white">Temel Modal</h3>
                        <div class="space-y-4">
                            <div class="flex flex-wrap gap-4">
                                <Button @click="showBasicModal = true">Temel Modal</Button>
                                <Button @click="showLargeModal = true">Büyük Modal</Button>
                                <Button @click="showSmallModal = true">Küçük Modal</Button>
                            </div>

                            <!-- Temel Modal -->
                            <Modal v-model="showBasicModal" title="Temel Modal">
                                <p class="text-gray-600 dark:text-zinc-300">Bu bir temel modal örneğidir. İçeriği istediğiniz gibi özelleştirebilirsiniz.</p>
                                <template #footer>
                                    <Button variant="outline" @click="showBasicModal = false">Kapat</Button>
                                    <Button @click="showBasicModal = false">Kaydet</Button>
                                </template>
                            </Modal>

                            <!-- Büyük Modal -->
                            <Modal v-model="showLargeModal" title="Büyük Modal" size="lg">
                                <div class="space-y-4">
                                    <p class="text-gray-600 dark:text-zinc-300">Bu bir büyük modal örneğidir. Daha fazla içerik göstermek için kullanılabilir.</p>
                                    <div class="rounded-lg border p-4 dark:border-zinc-700">
                                        <h4 class="text-sm font-medium text-gray-900 dark:text-white">Örnek İçerik</h4>
                                        <p class="mt-2 text-sm text-gray-600 dark:text-zinc-300">Lorem ipsum dolor sit amet consectetur adipisicing elit. Quisquam voluptates, quod, quia, voluptate quae voluptatem quibusdam voluptatibus quos quas quidem nesciunt. Quisquam, quae. Quisquam voluptates, quod, quia, voluptate quae voluptatem quibusdam voluptatibus quos quas quidem nesciunt. Quisquam, quae.</p>
                                    </div>
                                </div>
                                <template #footer>
                                    <Button variant="outline" @click="showLargeModal = false">Kapat</Button>
                                    <Button @click="showLargeModal = false">Kaydet</Button>
                                </template>
                            </Modal>

                            <!-- Küçük Modal -->
                            <Modal v-model="showSmallModal" title="Küçük Modal" size="sm">
                                <p class="text-gray-600 dark:text-zinc-300">Bu bir küçük modal örneğidir. Basit mesajlar için kullanılabilir.</p>
                                <template #footer>
                                    <Button variant="outline" @click="showSmallModal = false">Kapat</Button>
                                    <Button @click="showSmallModal = false">Tamam</Button>
                                </template>
                            </Modal>
                        </div>
                    </div>

                    <!-- Onay Dialogu -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-gray-900 dark:text-white">Onay Dialogu</h3>
                        <div class="space-y-4">
                            <div class="flex flex-wrap gap-4">
                                <Button variant="warning" @click="showWarningDialog = true">Uyarı Dialogu</Button>
                                <Button variant="danger" @click="showDangerDialog = true">Tehlike Dialogu</Button>
                                <Button variant="primary" @click="showInfoDialog = true">Bilgi Dialogu</Button>
                            </div>

                            <!-- Uyarı Dialogu -->
                            <ConfirmDialog v-model="showWarningDialog" title="İşlemi Onayla" message="Bu işlemi gerçekleştirmek istediğinizden emin misiniz?" type="warning" @confirm="handleConfirm" @cancel="handleCancel" />

                            <!-- Tehlike Dialogu -->
                            <ConfirmDialog v-model="showDangerDialog" title="Hesabı Sil" message="Hesabınızı silmek istediğinizden emin misiniz? Bu işlem geri alınamaz." type="danger" confirm-button-text="Sil" @confirm="handleConfirm" @cancel="handleCancel" />

                            <!-- Bilgi Dialogu -->
                            <ConfirmDialog v-model="showInfoDialog" title="Değişiklikleri Kaydet" message="Yaptığınız değişiklikleri kaydetmek istiyor musunuz?" type="info" confirm-button-text="Kaydet" @confirm="handleConfirm" @cancel="handleCancel" />
                        </div>
                    </div>

                    <!-- Alert Dialog -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-gray-900 dark:text-white">Alert Dialog</h3>
                        <div class="space-y-4">
                            <div class="flex flex-wrap gap-4">
                                <Button variant="success" @click="showSuccessAlert = true">Başarılı</Button>
                                <Button variant="danger" @click="showErrorAlert = true">Hata</Button>
                                <Button variant="warning" @click="showWarningAlert = true">Uyarı</Button>
                                <Button variant="primary" @click="showInfoAlert = true">Bilgi</Button>
                            </div>

                            <!-- Başarılı Alert -->
                            <AlertDialog v-model="showSuccessAlert" title="İşlem Başarılı" message="İşleminiz başarıyla tamamlandı." type="success" auto-close />

                            <!-- Hata Alert -->
                            <AlertDialog v-model="showErrorAlert" title="Hata" message="İşlem sırasında bir hata oluştu." description="Lütfen daha sonra tekrar deneyin veya destek ekibiyle iletişime geçin." type="error" />

                            <!-- Uyarı Alert -->
                            <AlertDialog v-model="showWarningAlert" title="Uyarı" message="Bu işlem geri alınamaz." type="warning" />

                            <!-- Bilgi Alert -->
                            <AlertDialog v-model="showInfoAlert" title="Bilgi" message="Yeni bir güncelleme mevcut." description="Yeni özellikleri görmek için <a href='#' class='text-blue-600 hover:underline dark:text-blue-400'>tıklayın</a>." type="info" />
                        </div>
                    </div>
                </section>

                <!-- Yükleme ve Durum Bileşenleri Documentation -->
                <section id="loader-components" class="space-y-8 mt-16">
                    <div class="border-b border-border pb-4">
                        <h2 class="text-2xl font-bold text-gray-900 dark:text-white">Yükleme ve Durum Bileşenleri</h2>
                        <p class="text-gray-600 dark:text-zinc-300 mt-2">Yükleme durumları ve boş/hata durumları için kullanılan bileşenler.</p>
                    </div>

                    <!-- Loading/Spinner -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-gray-900 dark:text-white">Loading/Spinner</h3>
                        <div class="p-6 border border-border rounded-lg space-y-6">
                            <div class="flex flex-wrap gap-8">
                                <Loading text="Yükleniyor..." />
                                <Loading variant="success" text="Kaydediliyor..." />
                                <Loading variant="danger" text="Siliniyor..." />
                                <Loading variant="warning" text="İşleniyor..." />
                            </div>
                            <div class="flex flex-wrap gap-8">
                                <Loading size="sm" text="Küçük" />
                                <Loading size="md" text="Orta" />
                                <Loading size="lg" text="Büyük" />
                            </div>
                            <div class="flex flex-wrap gap-8">
                                <Loading vertical text="Dikey" />
                                <Loading variant="info" vertical text="Dikey Info" />
                            </div>
                        </div>
                    </div>

                    <!-- Skeleton Loading -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-gray-900 dark:text-white">Skeleton Loading</h3>
                        <div class="p-6 border border-border rounded-lg space-y-6">
                            <div class="space-y-4">
                                <div class="space-y-2">
                                    <Skeleton variant="text" size="full" />
                                    <Skeleton variant="text" size="lg" />
                                    <Skeleton variant="text" size="md" />
                                    <Skeleton variant="text" size="sm" />
                                </div>
                                <div class="flex gap-4">
                                    <Skeleton variant="avatar" />
                                    <div class="space-y-2 flex-1">
                                        <Skeleton variant="text" size="md" />
                                        <Skeleton variant="text" size="sm" />
                                    </div>
                                </div>
                                <Skeleton variant="image" size="full" />
                            </div>
                        </div>
                    </div>

                    <!-- Empty State -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-gray-900 dark:text-white">Empty State</h3>
                        <div class="p-6 border border-border rounded-lg space-y-6">
                            <EmptyState title="Veri Bulunamadı" description="Aradığınız kriterlere uygun veri bulunamadı. Lütfen farklı bir arama yapmayı deneyin.">
                                <template #action>
                                    <Button variant="primary">Yeni Ekle</Button>
                                </template>
                            </EmptyState>
                        </div>
                    </div>

                    <!-- Error State -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-gray-900 dark:text-white">Error State</h3>
                        <div class="p-6 border border-border rounded-lg space-y-6">
                            <ErrorState title="Bir Hata Oluştu" message="Veriler yüklenirken bir hata oluştu. Lütfen daha sonra tekrar deneyin." details="Error: Network request failed" @retry="handleRetry" />
                        </div>
                    </div>
                </section>

                <!-- Switch -->
                <section id="switch" class="space-y-8 mt-16">
                    <div class="border-b border-border pb-4">
                        <h2 class="text-2xl font-bold text-white">Switch</h2>
                        <p class="text-gray-400 mt-2">Açma/kapama durumları için kullanılan toggle bileşeni.</p>
                    </div>

                    <!-- Import Section -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Import</h3>
                        <div class="border border-border p-4 rounded-md">
                            <code class="text-sm text-gray-300">import Switch from '@/components/ui/Switch.vue'</code>
                        </div>
                    </div>

                    <!-- Basic Usage -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Temel Kullanım</h3>
                        <div class="p-6 border border-border rounded-lg space-y-6">
                            <div class="flex flex-wrap gap-8">
                                <Switch v-model="switchState1" label="Temel Switch" />
                                <Switch v-model="switchState2" label="Varsayılan Açık" />
                                <Switch v-model="switchState3" label="Devre Dışı" disabled />
                            </div>
                            <div class="bg-muted/40 p-4 rounded-md">
                                <code class="text-sm text-gray-300">
                                    &lt;Switch v-model="switchState1" label="Temel Switch" /&gt;
                                    <br />
                                    &lt;Switch v-model="switchState2" label="Varsayılan Açık" /&gt;
                                    <br />
                                    &lt;Switch v-model="switchState3" label="Devre Dışı" disabled /&gt;
                                </code>
                            </div>
                        </div>
                    </div>

                    <!-- Sizes -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Boyutlar</h3>
                        <div class="p-6 border border-border rounded-lg space-y-6">
                            <div class="flex flex-wrap items-center gap-8">
                                <Switch v-model="switchState1" size="sm" label="Küçük" />
                                <Switch v-model="switchState1" size="md" label="Orta" />
                                <Switch v-model="switchState1" size="lg" label="Büyük" />
                            </div>
                            <div class="bg-muted/40 p-4 rounded-md">
                                <code class="text-sm text-gray-300">
                                    &lt;Switch v-model="value" size="sm" label="Küçük" /&gt;
                                    <br />
                                    &lt;Switch v-model="value" size="md" label="Orta" /&gt;
                                    <br />
                                    &lt;Switch v-model="value" size="lg" label="Büyük" /&gt;
                                </code>
                            </div>
                        </div>
                    </div>
                </section>

                <!-- Slider -->
                <section id="slider" class="space-y-8 mt-16">
                    <div class="border-b border-border pb-4">
                        <h2 class="text-2xl font-bold text-white">Slider</h2>
                        <p class="text-gray-400 mt-2">Değer aralığı seçimi için kullanılan slider bileşeni.</p>
                    </div>

                    <!-- Import Section -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Import</h3>
                        <div class="border border-border p-4 rounded-md">
                            <code class="text-sm text-gray-300">import Slider from '@/components/ui/Slider.vue'</code>
                        </div>
                    </div>

                    <!-- Basic Usage -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Temel Kullanım</h3>
                        <div class="p-6 border border-border rounded-lg space-y-6">
                            <div class="max-w-sm space-y-8">
                                <Slider v-model="sliderValue1" label="Temel Slider" />
                                <Slider v-model="sliderValue2" label="Adımlı Slider" :step="5" />
                                <Slider v-model="sliderValue3" label="Devre Dışı" disabled />
                            </div>
                            <div class="bg-muted/40 p-4 rounded-md">
                                <code class="text-sm text-gray-300">
                                    &lt;Slider v-model="value" label="Temel Slider" /&gt;
                                    <br />
                                    &lt;Slider v-model="value" label="Adımlı Slider" :step="5" /&gt;
                                    <br />
                                    &lt;Slider v-model="value" label="Devre Dışı" disabled /&gt;
                                </code>
                            </div>
                        </div>
                    </div>

                    <!-- Sizes -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Boyutlar</h3>
                        <div class="p-6 border border-border rounded-lg space-y-6">
                            <div class="max-w-sm space-y-8">
                                <Slider v-model="sliderValue1" size="sm" label="Küçük" />
                                <Slider v-model="sliderValue1" size="md" label="Orta" />
                                <Slider v-model="sliderValue1" size="lg" label="Büyük" />
                            </div>
                            <div class="bg-muted/40 p-4 rounded-md">
                                <code class="text-sm text-gray-300">
                                    &lt;Slider v-model="value" size="sm" label="Küçük" /&gt;
                                    <br />
                                    &lt;Slider v-model="value" size="md" label="Orta" /&gt;
                                    <br />
                                    &lt;Slider v-model="value" size="lg" label="Büyük" /&gt;
                                </code>
                            </div>
                        </div>
                    </div>

                    <!-- With Ticks -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">İşaretleyiciler</h3>
                        <div class="p-6 border border-border rounded-lg space-y-6">
                            <div class="max-w-sm space-y-8">
                                <Slider v-model="sliderValue1" label="İşaretleyicili Slider" :min="0" :max="100" :step="20" show-ticks />
                            </div>
                            <div class="bg-muted/40 p-4 rounded-md">
                                <code class="text-sm text-gray-300">
                                    &lt;Slider
                                    <br />
                                    &nbsp;&nbsp;v-model="value"
                                    <br />
                                    &nbsp;&nbsp;label="İşaretleyicili Slider"
                                    <br />
                                    &nbsp;&nbsp;:min="0"
                                    <br />
                                    &nbsp;&nbsp;:max="100"
                                    <br />
                                    &nbsp;&nbsp;:step="20"
                                    <br />
                                    &nbsp;&nbsp;show-ticks
                                    <br />
                                    /&gt;
                                </code>
                            </div>
                        </div>
                    </div>
                </section>

                <!-- ColorPicker -->
                <section id="colorpicker" class="space-y-8 mt-16">
                    <div class="border-b border-border pb-4">
                        <h2 class="text-2xl font-bold text-white">Color Picker</h2>
                        <p class="text-gray-400 mt-2">Renk seçimi için kullanılan color picker bileşeni.</p>
                    </div>

                    <!-- Import Section -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Import</h3>
                        <div class="border border-border p-4 rounded-md">
                            <code class="text-sm text-gray-300">import ColorPicker from '@/components/ui/ColorPicker.vue'</code>
                        </div>
                    </div>

                    <!-- Basic Usage -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Temel Kullanım</h3>
                        <div class="p-6 border border-border rounded-lg space-y-6">
                            <div class="max-w-sm space-y-8">
                                <ColorPicker v-model="colorValue1" label="Temel Color Picker" />
                                <ColorPicker v-model="colorValue2" label="Hazır Renkler" :preset-colors="presetColors" />
                                <ColorPicker v-model="colorValue3" label="Devre Dışı" disabled />
                            </div>
                            <div class="bg-muted/40 p-4 rounded-md">
                                <code class="text-sm text-gray-300">
                                    &lt;ColorPicker v-model="color" label="Temel Color Picker" /&gt;
                                    <br />
                                    &lt;ColorPicker v-model="color" label="Hazır Renkler" :preset-colors="presetColors" /&gt;
                                    <br />
                                    &lt;ColorPicker v-model="color" label="Devre Dışı" disabled /&gt;
                                </code>
                            </div>
                        </div>
                    </div>

                    <!-- With Preset Colors -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Hazır Renkler</h3>
                        <div class="p-6 border border-border rounded-lg space-y-6">
                            <div class="max-w-sm">
                                <ColorPicker v-model="colorValue1" label="Özel Hazır Renkler" :preset-colors="['#FF0000', '#00FF00', '#0000FF', '#FFFF00', '#FF00FF', '#00FFFF']" />
                            </div>
                            <div class="bg-muted/40 p-4 rounded-md">
                                <code class="text-sm text-gray-300">
                                    &lt;ColorPicker
                                    <br />
                                    &nbsp;&nbsp;v-model="color"
                                    <br />
                                    &nbsp;&nbsp;label="Özel Hazır Renkler"
                                    <br />
                                    &nbsp;&nbsp;:preset-colors="[
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;'#FF0000',
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;'#00FF00',
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;'#0000FF',
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;'#FFFF00',
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;'#FF00FF',
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;'#00FFFF',
                                    <br />
                                    &nbsp;&nbsp;]"
                                    <br />
                                    /&gt;
                                </code>
                            </div>
                        </div>
                    </div>
                </section>

                <!-- TimePicker -->
                <div class="space-y-6">
                    <div class="flex items-center justify-between">
                        <h3 class="text-lg font-medium text-zinc-200">TimePicker</h3>
                        <span class="text-sm text-zinc-400">Zaman seçici bileşeni</span>
                    </div>

                    <div class="grid gap-8">
                        <!-- Temel Kullanım -->
                        <div class="space-y-4">
                            <h4 class="text-sm font-medium text-zinc-300">Temel Kullanım</h4>
                            <div class="grid gap-4 md:grid-cols-2">
                                <TimePicker v-model="timeValue" label="24 Saat Formatı" />
                                <TimePicker v-model="time12hValue" label="12 Saat Formatı" format="12h" />
                            </div>
                            <CodeBlock :code="timePickerBasicCode" lang="vue" />
                        </div>

                        <!-- Devre Dışı Durum -->
                        <div class="space-y-4">
                            <h4 class="text-sm font-medium text-zinc-300">Devre Dışı Durum</h4>
                            <div class="grid gap-4 md:grid-cols-2">
                                <TimePicker v-model="timeValue" label="Devre Dışı" disabled />
                            </div>
                            <CodeBlock :code="timePickerDisabledCode" lang="vue" />
                        </div>
                    </div>
                </div>

                <!-- Medya Bileşenleri -->
                <section class="space-y-8">
                    <h2 class="text-2xl font-semibold text-white">Medya Bileşenleri</h2>

                    <!-- Video Player -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-medium text-white">Video Player</h3>
                        <VideoPlayer :src="videoSrc" poster="https://picsum.photos/800/450?random=1" :autoplay="false" :loop="false" :muted="false" />
                    </div>

                    <!-- Audio Player -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-medium text-white">Audio Player</h3>
                        <AudioPlayer :src="audioSrc" title="Sample Audio" artist="Unknown Artist" cover="https://picsum.photos/300/300?random=1" :autoplay="false" :loop="false" />
                    </div>

                    <!-- Carousel -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-medium text-white">Carousel</h3>
                        <Carousel :slides="carouselSlides" :autoplay="true" :interval="5000" aspect-ratio="16:9" :show-arrows="true" :show-indicators="true" :show-thumbnails="true" />
                    </div>

                    <!-- LightBox -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-medium text-white">LightBox</h3>
                        <LightBox :images="lightboxImages" :show-thumbnails="true" />
                    </div>

                    <!-- File Viewer -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-medium text-white">File Viewer</h3>
                        <FileViewer v-bind="sampleFile" aspect-ratio="16:9" :downloadable="true" :closable="true" />
                    </div>
                </section>

                <!-- Özelleştirme Bileşenleri -->
                <section class="space-y-8">
                    <div class="flex items-center justify-between">
                        <h2 class="text-2xl font-semibold text-white">Özelleştirme</h2>
                        <span class="text-sm text-zinc-400">Arayüz özelleştirme bileşenleri</span>
                    </div>

                    <!-- Theme Switcher -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-medium text-white">Tema Değiştirici</h3>
                        <div class="flex items-center gap-4">
                            <ThemeSwitcher />
                        </div>
                    </div>

                    <!-- Language Switcher -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-medium text-white">Dil Değiştirici</h3>
                        <div class="flex items-center gap-4">
                            <LanguageSwitcher />
                        </div>
                    </div>

                    <!-- Customizer -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-medium text-white">Arayüz Özelleştirici</h3>
                        <div class="relative h-[400px] rounded-lg border border-zinc-800 bg-zinc-900">
                            <!-- <Customizer /> -->
                        </div>
                    </div>
                </section>

                <!-- Güvenlik ve Doğrulama -->
                <section class="space-y-8">
                    <div class="flex items-center justify-between">
                        <h2 class="text-2xl font-semibold text-white">Güvenlik ve Doğrulama</h2>
                        <span class="text-sm text-zinc-400">Güvenlik ve kimlik doğrulama bileşenleri</span>
                    </div>

                    <!-- Captcha -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-medium text-white">Captcha</h3>
                        <div class="max-w-md">
                            <Captcha @verify="handleCaptchaVerify" />
                        </div>
                    </div>

                    <!-- Password Strength -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-medium text-white">Şifre Güçlüğü</h3>
                        <div class="max-w-md">
                            <PasswordStrength @input="handlePasswordInput" />
                        </div>
                    </div>

                    <!-- Biometric Auth -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-medium text-white">Biyometrik Doğrulama</h3>
                        <div class="grid gap-4 md:grid-cols-2">
                            <!-- Parmak İzi -->
                            <BiometricAuth type="fingerprint" @success="handleBiometricSuccess" @error="handleBiometricError" />
                            <!-- Yüz Tanıma -->
                            <BiometricAuth type="face" @success="handleBiometricSuccess" @error="handleBiometricError" />
                        </div>
                    </div>
                </section>

                <!-- İş Akışı Bileşenleri -->
                <section class="space-y-8">
                    <div class="flex items-center justify-between">
                        <h2 class="text-2xl font-semibold text-white">İş Akışı</h2>
                        <span class="text-sm text-zinc-400">Proje ve görev yönetimi bileşenleri</span>
                    </div>

                    <!-- Kanban -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-medium text-white">Kanban</h3>
                        <div class="overflow-hidden">
                            <Kanban @update:columns="handleKanbanUpdate" />
                        </div>
                    </div>

                    <!-- Calendar -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-medium text-white">Takvim</h3>
                        <Calendar @add-event="handleAddCalendarEvent" @edit-event="handleEditCalendarEvent" />
                    </div>

                    <!-- Gantt -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-medium text-white">Gantt Şeması</h3>
                        <Gantt @add-task="handleAddGanttTask" @edit-task="handleEditGanttTask" />
                    </div>

                    <!-- Scheduler -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-medium text-white">Zamanlayıcı</h3>
                        <Scheduler @add-event="handleAddSchedulerEvent" @edit-event="handleEditSchedulerEvent" />
                    </div>
                </section>

                <!-- Veri Görselleştirme -->
                <section class="space-y-8">
                    <h2 class="text-2xl font-semibold text-white">Veri Görselleştirme</h2>
                    <p class="text-zinc-400">Veri görselleştirme ve analiz bileşenleri.</p>

                    <!-- Ağaç Görünümü -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-medium text-white">Ağaç Görünümü</h3>
                        <div class="max-w-sm p-4 border border-zinc-800 rounded-lg">
                            <Tree :nodes="treeNodes" defaultExpanded iconSize="md" indentSize="md" />
                        </div>
                    </div>

                    <!-- Grafikler -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-medium text-white">Grafikler</h3>
                        <div class="grid gap-4 lg:grid-cols-2">
                            <!-- Çizgi Grafiği -->
                            <Chart
                                title="Aylık Satışlar"
                                description="Son 12 ayın satış verileri"
                                type="line"
                                :data="{
                                    labels: ['Oca', 'Şub', 'Mar', 'Nis', 'May', 'Haz', 'Tem', 'Ağu', 'Eyl', 'Eki', 'Kas', 'Ara'],
                                    datasets: [
                                        {
                                            label: 'Satışlar',
                                            data: [65, 59, 80, 81, 56, 55, 40, 45, 60, 75, 85, 90],
                                            borderColor: '#3b82f6',
                                            tension: 0.3,
                                        },
                                    ],
                                }"
                            />

                            <!-- Pasta Grafiği -->
                            <Chart
                                title="Kategori Dağılımı"
                                description="Ürün kategorilerine göre dağılım"
                                type="pie"
                                :data="{
                                    labels: ['Elektronik', 'Giyim', 'Kitap', 'Spor', 'Kozmetik'],
                                    datasets: [
                                        {
                                            data: [30, 25, 15, 20, 10],
                                            backgroundColor: ['#3b82f6', '#ef4444', '#10b981', '#f59e0b', '#8b5cf6'],
                                        },
                                    ],
                                }"
                            />
                        </div>
                    </div>

                    <!-- İlerleme Çubukları -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-medium text-white">İlerleme Çubukları</h3>
                        <div class="space-y-4">
                            <ProgressBar label="Temel" value="75" showValue />
                            <ProgressBar label="Özel Renk" value="60" color="bg-purple-500" showValue />
                            <ProgressBar label="Belirsiz" indeterminate />
                            <ProgressBar label="Nabız" value="90" color="bg-red-500" pulse showValue />
                        </div>
                    </div>

                    <!-- Zaman Çizelgesi -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-medium text-white">Zaman Çizelgesi</h3>
                        <Timeline
                            :items="[
                                {
                                    title: 'Sipariş Alındı',
                                    content: 'Sipariş başarıyla oluşturuldu.',
                                    date: '12 Mart 2024, 10:30',
                                    icon: 'ShoppingCartIcon',
                                    iconBackground: 'bg-blue-500',
                                },
                                {
                                    title: 'Ödeme Onaylandı',
                                    content: 'Ödeme işlemi tamamlandı.',
                                    date: '12 Mart 2024, 10:35',
                                    icon: 'CreditCardIcon',
                                    iconBackground: 'bg-green-500',
                                },
                                {
                                    title: 'Kargoya Verildi',
                                    content: 'Ürün kargo firmasına teslim edildi.',
                                    date: '13 Mart 2024, 14:20',
                                    icon: 'TruckIcon',
                                    iconBackground: 'bg-yellow-500',
                                },
                                {
                                    title: 'Teslim Edildi',
                                    content: 'Ürün müşteriye teslim edildi.',
                                    date: '14 Mart 2024, 11:45',
                                    icon: 'CheckCircleIcon',
                                    iconBackground: 'bg-green-500',
                                },
                            ]"
                        />
                    </div>

                    <!-- Veri Tablosu -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-medium text-white">Veri Tablosu</h3>
                        <DataGrid
                            :columns="[
                                { field: 'id', header: 'ID', sortable: true },
                                { field: 'name', header: 'Ad', sortable: true },
                                { field: 'category', header: 'Kategori', sortable: true },
                                { field: 'price', header: 'Fiyat', sortable: true },
                                { field: 'stock', header: 'Stok', sortable: true },
                            ]"
                            :rows="[
                                { id: 1, name: 'iPhone 15 Pro', category: 'Telefon', price: '84.999 ₺', stock: 25 },
                                { id: 2, name: 'MacBook Pro M3', category: 'Bilgisayar', price: '124.999 ₺', stock: 15 },
                                { id: 3, name: 'AirPods Pro', category: 'Aksesuar', price: '14.999 ₺', stock: 50 },
                                { id: 4, name: 'iPad Air', category: 'Tablet', price: '34.999 ₺', stock: 30 },
                                { id: 5, name: 'Apple Watch', category: 'Aksesuar', price: '24.999 ₺', stock: 40 },
                            ]"
                            selectable
                            actions
                        >
                            <template #actions="{ row }">
                                <button class="rounded-lg bg-blue-500 px-2 py-1 text-xs text-white hover:bg-blue-600" @click="() => {}">Düzenle</button>
                                <button class="rounded-lg bg-red-500 px-2 py-1 text-xs text-white hover:bg-red-600" @click="() => {}">Sil</button>
                            </template>
                        </DataGrid>
                    </div>
                </section>

                <!-- Tree Documentation -->
                <section id="tree" class="space-y-8 mt-16 hidden">
                    <div class="border-b border-border pb-4">
                        <h2 class="text-2xl font-bold text-white">Tree</h2>
                        <p class="text-gray-400 mt-2">Hiyerarşik veri yapılarını görüntülemek için ağaç bileşeni.</p>
                    </div>

                    <!-- Import Section -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Import</h3>
                        <div class="border border-border p-4 rounded-md">
                            <code class="text-sm text-gray-300">import Tree from '@/components/ui/Tree.vue'</code>
                        </div>
                    </div>

                    <!-- Props Section -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Props</h3>
                        <div class="overflow-x-auto">
                            <table class="w-full text-left border-collapse">
                                <thead>
                                    <tr class="border-b border-border">
                                        <th class="py-3 text-gray-400">Prop</th>
                                        <th class="py-3 text-gray-400">Tip</th>
                                        <th class="py-3 text-gray-400">Varsayılan</th>
                                        <th class="py-3 text-gray-400">Açıklama</th>
                                    </tr>
                                </thead>
                                <tbody class="text-gray-300">
                                    <tr class="border-b border-border">
                                        <td class="py-3 font-medium">nodes</td>
                                        <td>TreeNode[]</td>
                                        <td>[]</td>
                                        <td>Ağaç düğümlerinin listesi</td>
                                    </tr>
                                    <tr class="border-b border-border">
                                        <td class="py-3 font-medium">iconSize</td>
                                        <td>string</td>
                                        <td>'md'</td>
                                        <td>İkon boyutu (sm, md, lg)</td>
                                    </tr>
                                    <tr class="border-b border-border">
                                        <td class="py-3 font-medium">indentSize</td>
                                        <td>string</td>
                                        <td>'md'</td>
                                        <td>İç içe geçmiş öğelerin girinti boyutu</td>
                                    </tr>
                                    <tr class="border-b border-border">
                                        <td class="py-3 font-medium">defaultExpanded</td>
                                        <td>boolean</td>
                                        <td>false</td>
                                        <td>Başlangıçta tüm düğümlerin genişletilmiş olup olmayacağı</td>
                                    </tr>
                                    <tr class="border-b border-border">
                                        <td class="py-3 font-medium">defaultSelected</td>
                                        <td>(string | number)[]</td>
                                        <td>[]</td>
                                        <td>Başlangıçta seçili olan düğümlerin ID'leri</td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>

                    <!-- Tree Example Section -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-semibold text-white">Örnek</h3>
                        <div class="p-6 border border-border rounded-lg space-y-6">
                            <div class="max-w-sm">
                                <Tree :nodes="treeNodes" defaultExpanded />
                            </div>
                            <div class="bg-muted/40 p-4 rounded-md">
                                <code class="text-sm text-gray-300">&lt;Tree :nodes="treeNodes" defaultExpanded /&gt;</code>
                            </div>
                        </div>
                    </div>
                </section>

                <!-- Düzen Bileşenleri -->
                <section class="space-y-8">
                    <div class="flex items-center justify-between">
                        <h2 class="text-2xl font-semibold text-white">Düzen Bileşenleri</h2>
                        <span class="text-sm text-zinc-400">Sayfa düzeni ve yerleşim bileşenleri</span>
                    </div>

                    <!-- Accordion -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-medium text-white">Accordion</h3>
                        <div class="max-w-md">
                            <Accordion
                                :items="[
                                    {
                                        title: 'Accordion Başlık 1',
                                        content: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.',
                                    },
                                    {
                                        title: 'Accordion Başlık 2',
                                        content: 'Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.',
                                    },
                                    {
                                        title: 'Accordion Başlık 3',
                                        content: 'Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.',
                                    },
                                ]"
                            />
                        </div>
                    </div>

                    <!-- Tabs -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-medium text-white">Tabs</h3>
                        <div class="max-w-2xl">
                            <Tabs
                                :tabs="[
                                    {
                                        title: 'Sekme 1',
                                        content: 'Sekme 1 içeriği burada yer alır. Lorem ipsum dolor sit amet, consectetur adipiscing elit.',
                                    },
                                    {
                                        title: 'Sekme 2',
                                        content: 'Sekme 2 içeriği burada yer alır. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.',
                                    },
                                    {
                                        title: 'Sekme 3',
                                        content: 'Sekme 3 içeriği burada yer alır. Ut enim ad minim veniam, quis nostrud exercitation ullamco.',
                                    },
                                ]"
                            />
                        </div>
                    </div>

                    <!-- Drawer -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-medium text-white">Drawer</h3>
                        <div class="flex gap-4">
                            <Button @click="leftDrawerOpen = true">Sol Drawer</Button>
                            <Button @click="rightDrawerOpen = true">Sağ Drawer</Button>
                        </div>

                        <Drawer v-model="leftDrawerOpen" title="Sol Drawer" position="left">
                            <div class="space-y-4">
                                <p class="text-zinc-400">Sol drawer içeriği burada yer alır.</p>
                                <Button @click="leftDrawerOpen = false">Kapat</Button>
                            </div>
                        </Drawer>

                        <Drawer v-model="rightDrawerOpen" title="Sağ Drawer" position="right">
                            <div class="space-y-4">
                                <p class="text-zinc-400">Sağ drawer içeriği burada yer alır.</p>
                                <Button @click="rightDrawerOpen = false">Kapat</Button>
                            </div>
                        </Drawer>
                    </div>

                    <!-- Masonry -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-medium text-white">Masonry</h3>
                        <Masonry :columns="3" :gap="16">
                            <div v-for="i in 9" :key="i" class="rounded-lg bg-zinc-800 p-4" :style="{ height: 100 + Math.random() * 200 + 'px' }">
                                <h4 class="text-white">Öğe {{ i }}</h4>
                                <p class="mt-2 text-sm text-zinc-400">Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
                            </div>
                        </Masonry>
                    </div>

                    <!-- Virtual Scroll -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-medium text-white">Virtual Scroll</h3>
                        <div class="max-w-md">
                            <VirtualScroll
                                :items="
                                    Array.from({ length: 1000 }, (_, i) => ({
                                        id: i + 1,
                                        title: 'Öğe ' + (i + 1),
                                        description: 'Açıklama ' + (i + 1),
                                    }))
                                "
                                :height="400"
                                :item-height="80"
                            >
                                <template #default="{ item }">
                                    <div class="border-b border-zinc-800 p-4">
                                        <h4 class="text-white">{{ item.title }}</h4>
                                        <p class="mt-1 text-sm text-zinc-400">{{ item.description }}</p>
                                    </div>
                                </template>
                            </VirtualScroll>
                        </div>
                    </div>
                </section>

                <!-- Bildirim ve Geri Bildirim -->
                <section class="space-y-8">
                    <div class="flex items-center justify-between">
                        <h2 class="text-2xl font-semibold text-white">Bildirim ve Geri Bildirim</h2>
                        <span class="text-sm text-zinc-400">Kullanıcı etkileşimi ve bildirim bileşenleri</span>
                    </div>

                    <!-- Toast -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-medium text-white">Toast</h3>
                        <div class="flex flex-wrap gap-4">
                            <Button @click="showToast('success', 'Başarılı', 'İşlem başarıyla tamamlandı.')">Başarılı Toast</Button>
                            <Button @click="showToast('error', 'Hata', 'Bir hata oluştu.')">Hata Toast</Button>
                            <Button @click="showToast('warning', 'Uyarı', 'Dikkat edilmesi gereken bir durum var.')">Uyarı Toast</Button>
                            <Button @click="showToast('info', 'Bilgi', 'Yeni bir güncelleme mevcut.')">Bilgi Toast</Button>
                        </div>
                    </div>

                    <!-- Snackbar -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-medium text-white">Snackbar</h3>
                        <div class="flex flex-wrap gap-4">
                            <Button @click="showBasicSnackbar">Temel Snackbar</Button>
                            <Button @click="showActionSnackbar">Aksiyonlu Snackbar</Button>
                        </div>
                    </div>

                    <!-- Banner -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-medium text-white">Banner</h3>
                        <div class="flex flex-wrap gap-4">
                            <Button @click="showSuccessBanner">Başarılı Banner</Button>
                            <Button @click="showErrorBanner">Hata Banner</Button>
                            <Button @click="showWarningBanner">Uyarı Banner</Button>
                            <Button @click="showInfoBanner">Bilgi Banner</Button>
                        </div>
                    </div>

                    <!-- Stepper -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-medium text-white">Stepper</h3>
                        <div class="max-w-4xl">
                            <Stepper
                                v-model="currentStep"
                                :steps="[
                                    { title: 'Kişisel Bilgiler', description: 'Ad, soyad ve iletişim bilgileri' },
                                    { title: 'Adres Bilgileri', description: 'Teslimat adresi bilgileri' },
                                    { title: 'Ödeme', description: 'Ödeme yöntemi seçimi' },
                                    { title: 'Onay', description: 'Sipariş özeti ve onay' },
                                ]"
                                @finish="handleStepperFinish"
                            >
                                <template #default="{ step }">
                                    <div class="rounded-lg border border-zinc-800 bg-zinc-900 p-6">
                                        <div v-if="step === 0">
                                            <h4 class="text-lg font-medium text-white">Kişisel Bilgiler</h4>
                                            <p class="mt-2 text-zinc-400">Kişisel bilgilerinizi girin.</p>
                                        </div>
                                        <div v-else-if="step === 1">
                                            <h4 class="text-lg font-medium text-white">Adres Bilgileri</h4>
                                            <p class="mt-2 text-zinc-400">Teslimat adresinizi girin.</p>
                                        </div>
                                        <div v-else-if="step === 2">
                                            <h4 class="text-lg font-medium text-white">Ödeme</h4>
                                            <p class="mt-2 text-zinc-400">Ödeme yönteminizi seçin.</p>
                                        </div>
                                        <div v-else>
                                            <h4 class="text-lg font-medium text-white">Onay</h4>
                                            <p class="mt-2 text-zinc-400">Siparişinizi onaylayın.</p>
                                        </div>
                                    </div>
                                </template>
                            </Stepper>
                        </div>
                    </div>

                    <!-- Context Menu -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-medium text-white">Context Menu</h3>
                        <div class="max-w-sm">
                            <ContextMenu :items="contextMenuItems">
                                <div class="rounded-lg border border-zinc-800 bg-zinc-900 p-6 text-center text-zinc-400">Sağ tıklayın</div>
                            </ContextMenu>
                        </div>
                    </div>
                </section>

                <!-- Toast -->
                <Toast ref="toast" />

                <!-- Snackbar -->
                <Snackbar ref="snackbar" />

                <!-- Banner -->
                <Banner v-model="bannerVisible" :type="bannerType" :message="bannerMessage" :action="bannerAction" closable />

                <!-- Sosyal Medya Bileşenleri -->
                <section class="mb-12">
                    <h2 class="mb-6 text-2xl font-semibold text-white">Sosyal Medya Bileşenleri</h2>

                    <!-- Yorum Sistemi -->
                    <div class="mb-8 space-y-4">
                        <h3 class="text-lg font-medium text-white">Yorum Sistemi</h3>
                        <div class="rounded-lg bg-zinc-900 p-6">
                            <Comments
                                :initial-comments="[
                                    {
                                        id: 1,
                                        user: {
                                            id: 1,
                                            name: 'Ahmet Yılmaz',
                                            avatar: 'https://i.pravatar.cc/150?img=1',
                                        },
                                        content: 'Harika bir ürün! Kesinlikle tavsiye ederim.',
                                        date: new Date('2024-03-15T10:30:00'),
                                        likes: 5,
                                        isLiked: true,
                                        replies: [
                                            {
                                                id: 2,
                                                user: {
                                                    id: 2,
                                                    name: 'Mehmet Demir',
                                                    avatar: 'https://i.pravatar.cc/150?img=2',
                                                },
                                                content: 'Katılıyorum, gerçekten çok kaliteli.',
                                                date: new Date('2024-03-15T11:00:00'),
                                            },
                                        ],
                                    },
                                ]"
                            />
                        </div>
                    </div>

                    <!-- Paylaşım Düğmeleri -->
                    <div class="mb-8 space-y-4">
                        <h3 class="text-lg font-medium text-white">Paylaşım Düğmeleri</h3>
                        <div class="rounded-lg bg-zinc-900 p-6">
                            <div class="space-y-4">
                                <Share url="https://example.com" title="Örnek Paylaşım İçeriği" :show-quick-share="true" />
                            </div>
                        </div>
                    </div>

                    <!-- Beğeni/Tepki Sistemi -->
                    <div class="mb-8 space-y-4">
                        <h3 class="text-lg font-medium text-white">Beğeni/Tepki Sistemi</h3>
                        <div class="rounded-lg bg-zinc-900 p-6">
                            <div class="space-y-4">
                                <Like
                                    v-model="isLiked"
                                    :count="likeCount"
                                    :show-reactions="true"
                                    :show-likes-list="true"
                                    :likes-list="[
                                        {
                                            id: 1,
                                            name: 'Ahmet Yılmaz',
                                            avatar: 'https://i.pravatar.cc/150?img=1',
                                        },
                                        {
                                            id: 2,
                                            name: 'Mehmet Demir',
                                            avatar: 'https://i.pravatar.cc/150?img=2',
                                        },
                                        {
                                            id: 3,
                                            name: 'Ayşe Kaya',
                                            avatar: 'https://i.pravatar.cc/150?img=3',
                                        },
                                    ]"
                                />
                            </div>
                        </div>
                    </div>

                    <!-- Takip Et Düğmesi -->
                    <div class="mb-8 space-y-4">
                        <h3 class="text-lg font-medium text-white">Takip Et Düğmesi</h3>
                        <div class="rounded-lg bg-zinc-900 p-6">
                            <div class="space-y-4">
                                <div class="flex flex-wrap gap-4">
                                    <Follow v-model="isFollowing" :count="1234" show-count />
                                    <Follow variant="secondary" :loading="true" />
                                    <Follow disabled />
                                </div>
                            </div>
                        </div>
                    </div>
                </section>

                <!-- Form Bileşenleri -->
                <section class="space-y-8">
                    <div class="flex items-center justify-between">
                        <h2 class="text-2xl font-semibold text-white">Form Bileşenleri</h2>
                        <span class="text-sm text-zinc-400">Gelişmiş form bileşenleri</span>
                    </div>

                    <!-- OTP Input -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-medium text-white">OTP Doğrulama</h3>
                        <div class="max-w-md rounded-lg bg-zinc-900 p-6">
                            <OTPInput v-model="otpValue" :error="otpError" />
                            <div class="mt-4 flex items-center justify-between">
                                <span class="text-sm text-zinc-400">Doğrulama kodu: {{ otpValue }}</span>
                                <button @click="resetOTP" class="text-sm text-primary hover:text-primary/80">Sıfırla</button>
                            </div>
                        </div>
                    </div>

                    <!-- Rich Text Editor -->
                    <div class="space-y-4">
                        <h3 class="text-lg font-medium text-white">Zengin Metin Editörü</h3>
                        <div class="rounded-lg bg-zinc-900 p-6">
                            <RichTextEditor v-model="editorContent" />
                            <div class="mt-4">
                                <h4 class="mb-2 text-sm font-medium text-white">Önizleme:</h4>
                                <div class="rounded-lg border border-zinc-700 bg-zinc-800 p-4" v-html="editorContent"></div>
                            </div>
                        </div>
                    </div>
                </section>
            </div>
        </div>
    </div>
</template>

<script setup lang="ts">
import { ref, computed } from "vue";
import { DeviceTabletIcon, DevicePhoneMobileIcon, ComputerDesktopIcon, DocumentDuplicateIcon, PencilIcon, TrashIcon, ArrowPathIcon, ShareIcon } from "@heroicons/vue/24/outline";
import Button from "@/components/ui/Form/Button.vue";
import Input from "@/components/ui/Form/Input.vue";
import Select from "@/components/ui/Form/Select.vue";
import Loading from "@/components/ui/Utilities/Loading.vue";
import Alert from "@/components/ui/Feedback/Alert.vue";
import Badge from "@/components/ui/Data-Display/Badge.vue";
import Table from "@/components/ui/Table/Table.vue";
import TableHeader from "@/components/ui/Table/TableHeader.vue";
import TableHeaderCell from "@/components/ui/Table/TableHeaderCell.vue";
import TableBody from "@/components/ui/Table/TableBody.vue";
import TableRow from "@/components/ui/Table/TableRow.vue";
import TableCell from "@/components/ui/Table/TableCell.vue";
import Checkbox from "@/components/ui/Form/Checkbox.vue";
import Radio from "@/components/ui/Form/Radio.vue";
import Textarea from "@/components/ui/Form/Textarea.vue";
import DatePicker from "@/components/ui/Form/DatePicker.vue";
import FileUpload from "@/components/ui/Form/FileUpload.vue";
import List from "@/components/ui/Data-Display/List.vue";
import ListItem from "@/components/ui/Data-Display/ListItem.vue";
import Navbar from "@/components/ui/Layout/Navbar.vue";
import Sidebar from "@/components/layout/Sidebar.vue";
import Breadcrumb from "@/components/ui/Navigation/Breadcrumb.vue";
import BreadcrumbItem from "@/components/ui/Navigation/BreadcrumbItem.vue";
import Pagination from "@/components/ui/Navigation/Pagination.vue";
import Tooltip from "@/components/ui/Overlays/Tooltip.vue";
import Popover from "@/components/ui/Overlays/Popover.vue";
import Tag from "@/components/ui/Data-Display/Tag.vue";
import Avatar from "@/components/ui/Data-Display/Avatar.vue";
import Rating from "@/components/ui/Form/Rating.vue";
import ImageGallery from "@/components/ui/Media/ImageGallery.vue";
import ProductCard from "@/components/ui/Data-Display/ProductCard.vue";
import OrderCard from "@/components/ui/Data-Display/OrderCard.vue";
import StatisticCard from "@/components/ui/Data-Display/StatisticCard.vue";
import ProfileCard from "@/components/ui/Data-Display/ProfileCard.vue";
import Modal from "@/components/ui/Feedback/Modal.vue";
import ConfirmDialog from "@/components/ui/Feedback/ConfirmDialog.vue";
import AlertDialog from "@/components/ui/Feedback/AlertDialog.vue";
import Skeleton from "@/components/ui/Utilities/Skeleton.vue";
import EmptyState from "@/components/ui/Feedback/EmptyState.vue";
import ErrorState from "@/components/ui/Feedback/ErrorState.vue";
import Switch from "@/components/ui/Form/Switch.vue";
import Slider from "@/components/ui/Media/Slider.vue";
import ColorPicker from "@/components/ui/Form/ColorPicker.vue";
import TimePicker from "@/components/ui/Form/TimePicker.vue";
import VideoPlayer from "@/components/ui/Media/VideoPlayer.vue";
import AudioPlayer from "@/components/ui/Media/AudioPlayer.vue";
import Carousel from "@/components/ui/Media/Carousel.vue";
import LightBox from "@/components/ui/Media/LightBox.vue";
import FileViewer from "@/components/ui/Media/FileViewer.vue";
import ThemeSwitcher from "@/components/ui/Utilities/ThemeSwitcher.vue";
import LanguageSwitcher from "@/components/ui/Utilities/LanguageSwitcher.vue";
import Customizer from "@/components/ui/Overlays/Customizer.vue";
import Captcha from "@/components/ui/Form/Captcha.vue";
import PasswordStrength from "@/components/ui/Form/PasswordStrength.vue";
import BiometricAuth from "@/components/ui/Advanced/BiometricAuth.vue";
import Kanban from "@/components/ui/Data-Display/Kanban.vue";
import Calendar from "@/components/ui/Advanced/Calendar.vue";
import Gantt from "@/components/ui/Data-Display/Gantt.vue";
import Scheduler from "@/components/ui/Utilities/Scheduler.vue";
import Chart from "@/components/ui/Data-Display/Chart.vue";
import ProgressBar from "@/components/ui/Utilities/ProgressBar.vue";
import Timeline from "@/components/ui/Data-Display/Timeline.vue";
import Tree from "@/components/ui/Data-Display/Tree.vue";
import DataGrid from "@/components/ui/Data-Display/DataGrid.vue";
import Accordion from "@/components/ui/Data-Display/Accordion.vue";
import Tabs from "@/components/ui/Navigation/Tabs.vue";
import Drawer from "@/components/ui/Layout/Drawer.vue";
import Masonry from "@/components/ui/Data-Display/Masonry.vue";
import VirtualScroll from "@/components/ui/Data-Display/VirtualScroll.vue";
import Toast from "@/components/ui/Feedback/Toast.vue";
import Snackbar from "@/components/ui/Feedback/Snackbar.vue";
import Banner from "@/components/ui/Layout/Banner.vue";
import Stepper from "@/components/ui/Navigation/Stepper.vue";
import ContextMenu from "@/components/ui/Advanced/ContextMenu.vue";
import Comments from "@/components/ui/Utilities/Comments.vue";
import Share from "@/components/ui/Utilities/Share.vue";
import Like from "@/components/ui/Utilities/Like.vue";
import Follow from "@/components/ui/Utilities/Follow.vue";
import OTPInput from "@/components/ui/Form/OTPInput.vue";
import RichTextEditor from "@/components/ui/Form/RichTextEditor.vue";


interface SortState {
    field: keyof TableItem;
    direction: "asc" | "desc" | null;
}

interface TableData extends TableItem {
    name: string;
    email: string;
    role: string;
    status: string;
}

const users = ref<TableData[]>([
    {
        id: 1,
        name: "John Doe",
        email: "john@example.com",
        role: "Admin",
        status: "Active",
    },
    {
        id: 2,
        name: "Jane Smith",
        email: "jane@example.com",
        role: "User",
        status: "Inactive",
    },
]);

const selectedUsers = ref<TableData[]>([]);
const selectAll = ref(false);

const sortState = ref<SortState>({
    field: "name",
    direction: null,
});

const sortedUsers = computed(() => {
    const { field, direction } = sortState.value;
    if (!direction) return users.value;

    return [...users.value].sort((a, b) => {
        const aValue = a[field];
        const bValue = b[field];
        if (direction === "asc") {
            return aValue > bValue ? 1 : -1;
        } else {
            return aValue < bValue ? 1 : -1;
        }
    });
});

const handleSort = (field: keyof TableData) => {
    if (sortState.value.field === field) {
        sortState.value.direction = sortState.value.direction === "asc" ? "desc" : sortState.value.direction === "desc" ? null : "asc";
    } else {
        sortState.value = { field, direction: "asc" };
    }
};

const toggleSelectAll = () => {
    if (selectedUsers.value.length === users.value.length) {
        selectedUsers.value = [];
    } else {
        selectedUsers.value = users.value.map((user: TableItem) => user.id);
    }
};

const toggleSelectUser = (user: TableData) => {
    const index = selectedUsers.value.findIndex((u: TableData) => u.id === user.id);
    if (index === -1) {
        selectedUsers.value.push(user);
    } else {
        selectedUsers.value.splice(index, 1);
    }
};

const handleSelectAll = () => {
    selectAll.value = !selectAll.value;
    if (selectAll.value) {
        selectedUsers.value = [...users.value];
    } else {
        selectedUsers.value = [];
    }
};

// Checkbox States
const checkboxValue1 = ref(false);
const checkboxValue2 = ref(false);
const checkboxValue3 = ref(false);

const inlineCheckbox1 = ref(false);
const inlineCheckbox2 = ref(false);
const inlineCheckbox3 = ref(false);

const stateCheckbox1 = ref(false);
const stateCheckbox2 = ref(true);
const stateCheckbox3 = ref(false);

// Radio States
const radioValue = ref("1");
const inlineRadioValue = ref("1");
const stateRadioValue = ref("1");

// Date Picker States
const dateValue1 = ref("");
const dateValue2 = ref("");
const dateValue3 = ref("");
const dateValue4 = ref("");
const dateValue5 = ref("");

// File Upload States
const files1 = ref<File[]>([]);
const files2 = ref<File[]>([]);
const files3 = ref<File[]>([]);
const files4 = ref<File[]>([]);
const files5 = ref<File[]>([]);
const uploadProgress = ref(70);

// List Items
const listItems = ref([
    {
        title: "Liste Öğesi 1",
        description: "Açıklama metni 1",
    },
    {
        title: "Liste Öğesi 2",
        description: "Açıklama metni 2",
    },
    {
        title: "Liste Öğesi 3",
        description: "Açıklama metni 3",
    },
]);

const handleUserSelect = (user: TableItem) => {
    const index = selectedUsers.value.findIndex((u: TableItem) => u.id === user.id);
    if (index === -1) {
        selectedUsers.value.push(user);
    } else {
        selectedUsers.value.splice(index, 1);
    }
};

const handleListItemClick = (item: any) => {
    console.log("Liste öğesine tıklandı:", item);
};

// Pagination için gerekli state
const currentPage = ref(1);

// Yardımcı bileşenler için state'ler
const rating1 = ref(3);
const rating2 = ref(4);
const rating3 = ref(5);
const rating4 = ref(4.5);

// Modal States
const showBasicModal = ref(false);
const showLargeModal = ref(false);
const showSmallModal = ref(false);

// Confirm Dialog States
const showWarningDialog = ref(false);
const showDangerDialog = ref(false);
const showInfoDialog = ref(false);

// Alert Dialog States
const showSuccessAlert = ref(false);
const showErrorAlert = ref(false);
const showWarningAlert = ref(false);
const showInfoAlert = ref(false);

// Dialog Handlers
const handleConfirm = () => {
    console.log("Onaylandı");
};

const handleCancel = () => {
    console.log("İptal edildi");
};

const handleRetry = () => {
    console.log("Yeniden deneniyor...");
};

// Switch States
const switchState1 = ref(false);
const switchState2 = ref(true);
const switchState3 = ref(false);

// Slider States
const sliderValue1 = ref(50);
const sliderValue2 = ref(25);
const sliderValue3 = ref(75);

const presetColors = ["#FF0000", "#00FF00", "#0000FF", "#FFFF00", "#FF00FF", "#00FFFF", "#000000", "#FFFFFF"];

// ColorPicker States
const colorValue1 = ref("#FF0000");
const colorValue2 = ref("#00FF00");
const colorValue3 = ref("#0000FF");

const timeValue = ref("12:30");
const time12hValue = ref("02:30");

const timePickerBasicCode = `<TimePicker
  v-model="timeValue"
  label="24 Saat Formatı"
/>

<TimePicker
  v-model="time12hValue"
  label="12 Saat Formatı"
  format="12h"
/>`;

const timePickerDisabledCode = `<TimePicker
  v-model="timeValue"
  label="Devre Dışı"
  disabled
/>`;

// Medya Bileşenleri için örnek veriler
const videoSrc = "https://www.w3schools.com/html/mov_bbb.mp4";
const audioSrc = "https://www.w3schools.com/html/horse.mp3";

const carouselSlides = [
    {
        image: "https://picsum.photos/800/400?random=1",
        alt: "Slide 1",
        caption: "Güzel bir manzara",
    },
    {
        image: "https://picsum.photos/800/400?random=2",
        alt: "Slide 2",
        caption: "Şehir hayatı",
    },
    {
        image: "https://picsum.photos/800/400?random=3",
        alt: "Slide 3",
        caption: "Doğa harikası",
    },
];

const lightboxImages = [
    {
        src: "https://picsum.photos/1200/800?random=1",
        thumbnail: "https://picsum.photos/300/200?random=1",
        alt: "Image 1",
        caption: "Harika bir fotoğraf",
    },
    {
        src: "https://picsum.photos/1200/800?random=2",
        thumbnail: "https://picsum.photos/300/200?random=2",
        alt: "Image 2",
        caption: "Muhteşem manzara",
    },
    {
        src: "https://picsum.photos/1200/800?random=3",
        thumbnail: "https://picsum.photos/300/200?random=3",
        alt: "Image 3",
        caption: "Doğanın güzelliği",
    },
];

const sampleFile = {
    src: "https://www.w3.org/WAI/ER/tests/xhtml/testfiles/resources/pdf/dummy.pdf",
    fileName: "sample.pdf",
    fileSize: 1024 * 1024, // 1MB
    fileType: "PDF Document",
};

// Event handlers
const handleCaptchaVerify = (success: boolean) => {
    console.log("Captcha verification:", success ? "success" : "failed");
};

const handlePasswordInput = (password: string) => {
    console.log("Password input:", password);
};

const handleBiometricSuccess = () => {
    console.log("Biometric authentication successful");
};

const handleBiometricError = (error: any) => {
    console.error("Biometric authentication failed:", error);
};

// İş Akışı Bileşenleri için Event Handlers
const handleKanbanUpdate = (columns: any) => {
    console.log("Kanban columns updated:", columns);
};

const handleAddCalendarEvent = (date?: Date) => {
    console.log("Add calendar event:", date);
};

const handleEditCalendarEvent = (event: any) => {
    console.log("Edit calendar event:", event);
};

const handleAddGanttTask = () => {
    console.log("Add gantt task");
};

const handleEditGanttTask = (task: any) => {
    console.log("Edit gantt task:", task);
};

const handleAddSchedulerEvent = (date?: Date) => {
    console.log("Add scheduler event:", date);
};

const handleEditSchedulerEvent = (event: any) => {
    console.log("Edit scheduler event:", event);
};

const treeNodes = ref([
    {
        id: 1,
        label: "Elektronik",
        icon: DeviceTabletIcon,
        iconColor: "text-blue-500",
        children: [
            {
                id: 2,
                label: "Telefonlar",
                icon: DevicePhoneMobileIcon,
                children: [
                    {
                        id: 3,
                        label: "iPhone",
                        icon: DevicePhoneMobileIcon,
                    },
                    {
                        id: 4,
                        label: "Samsung",
                        icon: DevicePhoneMobileIcon,
                    },
                ],
            },
            {
                id: 5,
                label: "Bilgisayarlar",
                icon: ComputerDesktopIcon,
                children: [
                    {
                        id: 6,
                        label: "Dizüstü",
                        icon: ComputerDesktopIcon,
                    },
                    {
                        id: 7,
                        label: "Masaüstü",
                        icon: ComputerDesktopIcon,
                    },
                ],
            },
        ],
    },
]);

// Drawer durumları
const leftDrawerOpen = ref(false);
const rightDrawerOpen = ref(false);

// Toast referansı
const toast = ref();

// Toast gösterme fonksiyonu
const showToast = (type: "success" | "error" | "warning" | "info", title: string, message?: string) => {
    toast.value?.[type](title, message);
};

// Snackbar referansı
const snackbar = ref();

// Snackbar gösterme fonksiyonları
const showBasicSnackbar = () => {
    snackbar.value?.show({
        message: "Bu bir temel snackbar mesajıdır.",
    });
};

const showActionSnackbar = () => {
    snackbar.value?.show({
        message: "İşlem geri alındı.",
        action: {
            label: "Geri Al",
            callback: () => {
                console.log("Geri alma işlemi gerçekleştirildi");
            },
        },
    });
};

// Banner durumları
const bannerVisible = ref(false);
const bannerType = ref<"success" | "error" | "warning" | "info">("info");
const bannerMessage = ref("");
const bannerAction = ref<{ label: string; callback: () => void } | undefined>();

// Banner gösterme fonksiyonları
const showSuccessBanner = () => {
    bannerType.value = "success";
    bannerMessage.value = "İşlem başarıyla tamamlandı!";
    bannerVisible.value = true;
};

const showErrorBanner = () => {
    bannerType.value = "error";
    bannerMessage.value = "Bir hata oluştu. Lütfen tekrar deneyin.";
    bannerVisible.value = true;
};

const showWarningBanner = () => {
    bannerType.value = "warning";
    bannerMessage.value = "Bu işlem geri alınamaz!";
    bannerAction.value = {
        label: "Anladım",
        callback: () => {
            bannerVisible.value = false;
        },
    };
    bannerVisible.value = true;
};

const showInfoBanner = () => {
    bannerType.value = "info";
    bannerMessage.value = "Yeni özellikler eklendi! Keşfetmek için tıklayın.";
    bannerAction.value = {
        label: "Keşfet",
        callback: () => {
            console.log("Yeni özellikler keşfediliyor...");
            bannerVisible.value = false;
        },
    };
    bannerVisible.value = true;
};

// Stepper durumu
const currentStep = ref(0);

const handleStepperFinish = () => {
    showToast("success", "Tamamlandı", "Tüm adımlar başarıyla tamamlandı.");
};

// Context Menu öğeleri
const contextMenuItems = [
    {
        label: "Düzenle",
        icon: PencilIcon,
        action: () => console.log("Düzenle"),
    },
    {
        label: "Kopyala",
        icon: DocumentDuplicateIcon,
        action: () => console.log("Kopyala"),
    },
    {
        label: "Paylaş",
        icon: ShareIcon,
        action: () => console.log("Paylaş"),
    },
    { type: "divider" },
    {
        label: "Yenile",
        icon: ArrowPathIcon,
        action: () => console.log("Yenile"),
    },
    { type: "divider" },
    {
        label: "Sil",
        icon: TrashIcon,
        action: () => console.log("Sil"),
    },
];

// Beğeni durumu
const isLiked = ref(false);
const likeCount = ref(42);

// Takip durumu
const isFollowing = ref(false);

// Form Bileşenleri için yeni değişkenler
const otpValue = ref("");
const otpError = ref("");
const editorContent = ref("<p>Merhaba! Bu bir <strong>zengin metin</strong> editörüdür.</p>");

const resetOTP = () => {
    otpValue.value = "";
    otpError.value = "";
};
</script>
