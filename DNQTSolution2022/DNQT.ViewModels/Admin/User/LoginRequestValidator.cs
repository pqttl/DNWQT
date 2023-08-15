using FluentValidation;

namespace DNQT.ViewModels.Admin.User
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest_ViewModel>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.StrUserName).NotEmpty().WithMessage("Tên đăng nhập không được để trống!")
                .MinimumLength(6).WithMessage("Tên đăng nhập phải từ 7 kí tự trở lên!");
            RuleFor(x => x.StrPassword).NotEmpty().WithMessage("Mật khẩu không được để trống!")
                .MinimumLength(6).WithMessage("Mật khẩu phải từ 7 kí tự trở lên!");
        }
    }
}
