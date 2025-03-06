using AsmC5.DTOs.AuthDtos;
using AsmC5.DTOs.CartDtos;
using AsmC5.DTOs.CartItemDtos;
using AsmC5.DTOs.CategoryDtos;
using AsmC5.DTOs.ComboDtos;
using AsmC5.DTOs.ComboFoodDetailsDtos;
using AsmC5.DTOs.ComboFoodItemDtos;
using AsmC5.DTOs.FoodItemDtos;
using AsmC5.DTOs.OrderDetailDtos;
using AsmC5.DTOs.OrderDtos;
using AsmC5.DTOs.UserDtos;
using AsmC5.Models;
using AutoMapper;

namespace AsmC5.Mappings
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {       // Ánh xạ từ Category sang CategoryDto
            CreateMap<Category, CategoryDto>();

            // Ánh xạ từ Category sang CategoryForCreateDto
            CreateMap<Category, CategoryForCreateDto>();

            // Ánh xạ từ Category sang CategoryForUpdateDto
            CreateMap<Category, CategoryForUpdateDto>();

            // Ánh xạ từ CategoryForUpdateDto sang Category (trong trường hợp cập nhật)
            CreateMap<CategoryForUpdateDto, Category>()
                .ForMember(dest => dest.CategoryID, opt => opt.Ignore());  // Không ánh xạ CategoryID vì là khóa chính
            // Ánh xạ từ SignUpDto sang ApplicationUser
            CreateMap<SignUpDto, ApplicationUser>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore()) // Để hệ thống tự xử lý password hash
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => DateTime.Parse(src.DateOfBirth)))

                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber));

            // Ánh xạ từ SignInDto sang ApplicationUser
            CreateMap<SignInDto, ApplicationUser>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email)) // Email dùng làm Username
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore()); // Để hệ thống tự xử lý password hash
            //CART

            CreateMap<CartForCreateDto, Cart>()
                .ForMember(dest => dest.CartID, opt => opt.Ignore());
            CreateMap<Cart, CartDto>()
                .ForMember(dest => dest.CartItems, opt => opt.MapFrom(c => c.CartItems));
            //CART

            //cartitem
            CreateMap<CartItemForCreateDto, CartItem>()
                .ForMember(dest => dest.QuantityFoodItem, opt => opt.MapFrom(src => src.QuantityFoodItem))
                .ForMember(dest => dest.QuantityCombo, opt => opt.MapFrom(src => src.QuantityCombo))
                .ForMember(dest => dest.FoodItemID, opt => opt.MapFrom(src => src.FoodItemID))
                .ForMember(dest => dest.ComboID, opt => opt.MapFrom(src => src.ComboID))
                .ForMember(dest => dest.Price, opt => opt.Ignore()); // Chưa có giá trong DTO, có thể tính sau trong Service
            CreateMap<CartItemForUpdateDto, CartItem>()
                .ForMember(dest => dest.QuantityFoodItem, opt => opt.MapFrom(src => src.QuantityFoodItem))
                .ForMember(dest => dest.QuantityCombo, opt => opt.MapFrom(src => src.QuantityCombo));
            CreateMap<CartItem, CartItemDto>()
                .ForMember(dest => dest.CartID, opt => opt.MapFrom(src => src.CartID))
                .ForMember(dest => dest.FoodItemID, opt => opt.MapFrom(src => src.FoodItemID))
                .ForMember(dest => dest.QuantityFoodItem, opt => opt.MapFrom(src => src.QuantityFoodItem))
                .ForMember(dest => dest.ComboID, opt => opt.MapFrom(src => src.ComboID))
                .ForMember(dest => dest.QuantityCombo, opt => opt.MapFrom(src => src.QuantityCombo))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price));

            //cartitem
            //foodItem
            CreateMap<FoodItem, FoodItemDto>()
                .ForMember(dest => dest.FoodItemId, opt => opt.MapFrom(src => src.FoodItemId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.IsAvailable, opt => opt.MapFrom(src => src.IsAvailable))
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate))
                .ForMember(dest => dest.ImagePath, opt => opt.MapFrom(src => src.ImagePath))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category));


            CreateMap<FoodItemForCreateDto, FoodItem>()
                .ForMember(dest => dest.FoodItemId, opt => opt.Ignore()) // ID tự động tăng, không cần map
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.IsAvailable, opt => opt.MapFrom(src => src.IsAvailable))
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate))
                .ForMember(dest => dest.ImagePath, opt => opt.MapFrom(src => src.ImagePath))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.CategoryID, opt => opt.MapFrom(src => src.CategoryID))
                .ForMember(dest => dest.Category, opt => opt.Ignore()); // Chỉ lưu `CategoryID`, không cần ánh xạ `Category`

            CreateMap<FoodItemForUpdateDto, FoodItem>()
                .ForMember(dest => dest.CategoryID, opt => opt.MapFrom(src => src.CategoryID))
                .ForMember(dest => dest.Category, opt => opt.Ignore()); // Chỉ cập nhật `CategoryID`, không cập nhật `Category`
            CreateMap<FoodItem, FoodItemForUpdateDto>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category));
            CreateMap<ProductForUpdateQuantityDto, FoodItem>()
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity));

            //foodItem


            //orderdetail
            CreateMap<OrderDetail, OrderDetailDto>();
            CreateMap<OrderDetailDto, OrderDetail>()
                .ForMember(dest => dest.Order, opt => opt.Ignore())
                .ForMember(dest => dest.FoodItem, opt => opt.MapFrom(src => src.FoodItem))
                .ForMember(dest => dest.Combo, opt => opt.MapFrom(src => src.Combo));

            //orderdetail


            //order
            // Mapping Order -> OrderDto
            CreateMap<Order, OrderDto>()

                .ForMember(dest => dest.OrderDetails, opt => opt.MapFrom(src => src.OrderDetails));

            // Mapping OrderDto -> Order (Không cần thiết vì DTO này chỉ dùng để trả về dữ liệu)
            CreateMap<OrderDetail, OrderDetailDto>()
                .ForMember(dest => dest.FoodItem, opt => opt.MapFrom(src => src.FoodItem))
                .ForMember(dest => dest.Combo, opt => opt.MapFrom(src => src.Combo));
            // Mapping OrderForCreateDto -> Order
            CreateMap<OrderForCreateDto, Order>()
                .ForMember(dest => dest.OrderTime, opt => opt.MapFrom(_ => DateTime.Now)) // Gán thời gian khi tạo
                .ForMember(dest => dest.TotalAmount, opt => opt.Ignore()) // Tổng tiền sẽ tính từ giỏ hàng
                
                .ForMember(dest => dest.OrderDetails, opt => opt.Ignore());

            // Mapping OrderForUpdate -> Order
            CreateMap<OrderForUpdate, Order>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));
            //ỏder
            // Mapping từ ApplicationUser -> UserDto
            CreateMap<ApplicationUser, UserDto>()
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth.ToString("yyyy-MM-dd")))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Roles, opt => opt.Ignore()); // Bỏ qua danh sách roles

            // Mapping từ ApplicationUser -> UserProfileDto
            CreateMap<ApplicationUser, UserProfileDto>()
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth.ToString("yyyy-MM-dd")))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.UserName));

            // Mapping từ ApplicationUser -> UpdateProfileDto
            CreateMap<ApplicationUser, UpdateProfileDto>()
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth.ToString("yyyy-MM-dd")));
            CreateMap<ApplicationUser, UserUpdateForAdmin>()
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth.ToString("yyyy-MM-dd")));

            // Mapping từ UpdateProfileDto -> ApplicationUser (cập nhật hồ sơ)
            CreateMap<UpdateProfileDto, ApplicationUser>()
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => DateTime.Parse(src.DateOfBirth)))
                .ForMember(dest => dest.UserName, opt => opt.Ignore());


            // Mapping từ ChangePasswordDto -> ApplicationUser (chỉ để xác định User cần đổi mật khẩu)
            CreateMap<ChangePasswordDto, ApplicationUser>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName));

            

            CreateMap<ComboFoodItem, ComboFoodItemDto>()
                .ForMember(dest => dest.ComboFoodItemDetails, opt => opt.MapFrom(src => src.ComboFoodItemDetails))
                .ReverseMap();

            CreateMap<ComboFoodItem, ComboFoodItemDto>()
                .ForMember(dest => dest.ComboFoodItemDetails, opt => opt.MapFrom(src => src.ComboFoodItemDetails))
                .ReverseMap();


            CreateMap<ComboFoodItemDetail, ComboFoodItemDetailsFto>().ReverseMap();
            // Mapping từ Combo -> ComboDto
            CreateMap<Combo, ComboDto>()
                .ForMember(dest => dest.ComboFoodItemViews, opt => opt.MapFrom(src => src.ComboFoodItems))
                .ForMember(dest => dest.ComboFoodItemDetailsFtos, opt => opt.Ignore()); // Chưa rõ model gốc của ComboFoodItemDetails

            // Mapping từ ComboDto -> Combo (khi lưu vào DB)
            CreateMap<ComboDto, Combo>()
                .ForMember(dest => dest.ComboFoodItems, opt => opt.Ignore()) // Không map ngược danh sách
                .ForMember(dest => dest.ComboID, opt => opt.MapFrom(src => src.ComboID));

            // Mapping từ ComboFoodItem -> ComboFoodItemViewDto
            CreateMap<ComboFoodItem, ComboFoodItemViewDto>()
                .ForMember(dest => dest.FoodItemDtos, opt => opt.MapFrom(src => src.FoodItem))
            
                .ForMember(dest => dest.ComboFoodItemDetailsFto, opt => opt.Ignore()); // Tránh trùng lặp

            // Mapping từ ComboFoodItemViewDto -> ComboFoodItem
            CreateMap<ComboFoodItemViewDto, ComboFoodItem>()
                .ForMember(dest => dest.Combo, opt => opt.Ignore())
                .ForMember(dest => dest.FoodItem, opt => opt.Ignore());

            // Mapping từ ComboFoodItemDetails -> ComboFoodItemDetailsFto
            CreateMap<ComboFoodItemDetail, ComboFoodItemDetailsFto>()
                .ForMember(dest => dest.ComboFoodItemDto, opt => opt.MapFrom(src => src.ComboFoodItems));

            // Mapping từ ComboFoodItemDetailsFto -> ComboFoodItemDetails
            CreateMap<ComboFoodItemDetailsFto, ComboFoodItemDetail>()
                .ForMember(dest => dest.ComboFoodItems, opt => opt.Ignore());

            // Mapping từ Category -> CategoryDto
            CreateMap<Category, CategoryDto>();

            // Mapping từ CategoryDto -> Category (ngược lại)
            CreateMap<CategoryDto, Category>();

            // Mapping từ CategoryForCreateDto -> Category
            CreateMap<CategoryForCreateDto, Category>();

            // Mapping từ CategoryForUpdateDto -> Category
            CreateMap<CategoryForUpdateDto, Category>();




        }
    }
    

}
