'use client';
import { IGridComponent } from '@/app/interfaces/IGridComponent';
import GUTAtividadesGrid from '@/app/GerAdv_TS/GUTAtividades/Crud/Grids/GUTAtividadesGrid';
export class GUTAtividadesGridAdapter implements IGridComponent {
  render(): React.ReactNode {
    return <GUTAtividadesGrid />;
  }
}