'use client';
import { IGridComponent } from '@/app/interfaces/IGridComponent';
import GUTAtividadesMatrizGrid from '@/app/GerAdv_TS/GUTAtividadesMatriz/Crud/Grids/GUTAtividadesMatrizGrid';
export class GUTAtividadesMatrizGridAdapter implements IGridComponent {
  render(): React.ReactNode {
    return <GUTAtividadesMatrizGrid />;
  }
}