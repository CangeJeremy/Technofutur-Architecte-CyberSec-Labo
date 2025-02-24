CREATE FUNCTION [dbo].[HashPwd]
(
	@Pwd NVARCHAR(64)
)
RETURNS BINARY(64)
AS
BEGIN
	DECLARE @PreSalt NCHAR(1024) = N'vMB,:*@]2_9:AXb2a;]NLd)yP=kgbqr4VA.VFKqPZj;QV_i2{%N3#X%Qj)fraE=S8J*YGY$V17yjJ94C,g{XYKyxnBH0=}B9RbNFE)F2A/%h1x;Dnc9d/gM/efz%xY4+fLty}]wB_ccV61T+.{v1Cpu%_=&E$k[4i==[b!81p:/UF9S}6?-#Q3Xc.c3+bez-mi(7kknP$Cpu8Hn?62VP-]d,A)@}m.5m;+cqNQHBP#iUraPVW.ncSdg6XG=Zx8%aiaTSB3*#{hia_b!WndhP:#z-)a*}!BnbZB0vwf;ySK7H_b:0awDJE6.*4UW.z!=S1E4)CP3QLZ9{hhJ]0Ki_!@v(SPXM5=k7_[{m-.Gv%&bv{ycq3dE4Rt+wv,/rV[;Lp6&(a(6J_4de9ry,cL(+Z1N2#@Q1$6;!21-Tp&x(m]dW:K4Mdc*r=CR40A&Z%B:+%/h27ChYvF&)R;@yx!M_g&y@rxcMGgXG1wHGuMQpF2n[+1PkMhh(!PZQP7gz:A[vMpqLTNC&&g5Yujn2FW%R_rAUzmTw;]*JGmYyKb54-E-;i@L+[QY*.}7[W{5NLg.tKUT.(N[Kv,y;6a8@%v[+6SXTNaKu)R2uR9.DzuX;BUVpq1{1#]5K-S=tX;QB#rxdtqtWMjpu-a(AZ/Jcf:K8&wcZ}$DimkT;ZS@e=*cZUtmjh@p?iU;Y]b411CccNvKg,2D]zX2@X%p=rhFX}A2K#Nw87L8?+)/[pSzN0Phu!5z{;q3&w-ff$R[S#&xuSq:g7x?b;uA%zUn%$5-XG*Zqp0V1rvGvFc!S_(3]1#V_{(Mf]:(L}xB;Mr.!WQ(,Z6TF[C9WAy9g(rib%hCQX?1?ac/ga.z+7y2d}.1a+bg!Hm-N#iq7=X;B_qjDgRQ-4Tn5%p@?dx#n{.vSYTgijzW&!HWTxVf;H=Kw})%YZ%FMfE]i7UUxVk]qW+G}ZkSP11EP&;SftpQc4B6]f:pQ!8!(,/P6A;=047)V!eTcwLD/TniE]AkH:f$*tr&r*MG;5D:g';
	DECLARE @PostSalt NCHAR(1024) = N';?G_m{xCF{6ZBVZQ3P3jxeJ%AR_Er(,mq+fV.U@XSyANR)!B!GT;g8beign$b0adL0h](f:kvc}J&TT3Q?1pB@{YQ)?L};2[H;M1g.u@;!WeF=,tUgTSU)Va:z=E3CJjb3*8qF%Zd1mB[@n.KP1!X+H*EUDg2(8E&WL:*5v=/LPC31FXhe]uVFkY!&2GpF**1jfq_2)Y}Z#8$j9&apW.dQ/Wt]a(WXRxV,z=(d%+!0/-78$*eE7i3P;G:Df5%ZGN&7zvX[z?Dme,_yGz*;E$wd78&2JE?cA10_,@fMr{&Gig4FU7%;,R4n*Z9#dE[27Bf3_v7{Gx+uCj-#b2zMAB.{AA$PCjybR!2YQ3+%BiMt#hC_ST$+rAGEQWwq9z%H]S6eZFf3EFP$[m8h=C7j(]D$WiBAUd.Y77;w1jB}[1&!!LPGve(&:2KQ#F9n4Ad4-DLrc%LL,w?:5!A@;YMN?R&dP%!N#89.Wp231+@!.zf:X9:XhBRk9KTzG}PmgXZeGQYbY=_5Dgw[A9X%v7(Eyfmr2#N@*xTeieD[CXyK[gzFpT:ix@9d;}8/S76GNEp5*mhrR+my_[2&$iZU+Xc_}f3?Dtk,?Jub-NG@_a/K/MiS0nP&}Tp:AeUr_Kpt0.!dX4U7gVNY)DBdk3d#,V=UrV9TyCk9MkK6Q/1H.Gx]50aF%6DiH&=]*F{Y2&mX+}1Fd}2zLK7,K[H7K6!.W(m%w,Du3kKQcm_,J&@NhFT-*M_L+4$w;)Q#y?8N2Uxu}Rr#byj}d9Gz7U+Bym?JJGka&d7Uep-JfXa,i2#EV[7@x@iuY*f4MHSG{TuuzU2]Njg!.,U;QEBr{:xYnE$bS.Vw}GCSXf*yt0J_j92HVJ1B*hSDBL_6?UwQi17J6y%fU.{+nFF=5cR!E{WY#dYZ[$V/}KN:+#9N@04=LvQS-#eA;bRi3!M]$D+zZdMkN6Q{/L9cf;VVSLN$w1Yj(ew/*t-w7f(Bn%Q]eXj$y1F(eb/95ky40&=LY8.me?D5a.wR[Ev#p#';

	RETURN HASHBYTES('SHA2_512', CONCAT(@PreSalt, @Pwd, @PostSalt));
END
