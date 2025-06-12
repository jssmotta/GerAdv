'use client';
import { IGridComponent } from '@/app/interfaces/IGridComponent';
import TipoEnderecoGrid from '@/app/GerAdv_TS/TipoEndereco/Crud/Grids/TipoEnderecoGrid';
export class TipoEnderecoGridAdapter implements IGridComponent {
  render(): React.ReactNode {
    return <TipoEnderecoGrid />;
  }
}