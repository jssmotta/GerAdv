'use client';
import { IGridComponent } from '@/app/interfaces/IGridComponent';
import AtividadesGrid from '@/app/GerAdv_TS/Atividades/Crud/Grids/AtividadesGrid';
export class AtividadesGridAdapter implements IGridComponent {
  render(): React.ReactNode {
    return <AtividadesGrid />;
  }
}