﻿namespace MultiShop.Discount.Dtos
{
    public class UpdateDiscountCouponDto
    {
        public int CouponId { get; set; } //kupon id
        public string Code { get; set; } //kupon kodu
        public int Rate { get; set; } //kupon indirim oranı
        public bool IsActive { get; set; } //kupon aktif mi pasif
        public DateTime ValidDate { get; set; } //kupon geçerlikik tarihi
    }
}
