'use client';
import { IGridComponent } from '@/app/interfaces/IGridComponent';
import GruposEmpresasGrid from '@/app/GerAdv_TS/GruposEmpresas/Crud/Grids/GruposEmpresasGrid';
export class GruposEmpresasGridAdapter implements IGridComponent {
  render(): React.ReactNode {
    return <GruposEmpresasGrid />;
  }
}