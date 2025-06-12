'use client';
import { IGridComponent } from '@/app/interfaces/IGridComponent';
import TipoEnderecoSistemaGrid from '@/app/GerAdv_TS/TipoEnderecoSistema/Crud/Grids/TipoEnderecoSistemaGrid';
export class TipoEnderecoSistemaGridAdapter implements IGridComponent {
  render(): React.ReactNode {
    return <TipoEnderecoSistemaGrid />;
  }
}