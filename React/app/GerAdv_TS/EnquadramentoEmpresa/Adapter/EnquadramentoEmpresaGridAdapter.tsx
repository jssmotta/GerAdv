'use client';
import { IGridComponent } from '@/app/interfaces/IGridComponent';
import EnquadramentoEmpresaGrid from '@/app/GerAdv_TS/EnquadramentoEmpresa/Crud/Grids/EnquadramentoEmpresaGrid';
export class EnquadramentoEmpresaGridAdapter implements IGridComponent {
  render(): React.ReactNode {
    return <EnquadramentoEmpresaGrid />;
  }
}