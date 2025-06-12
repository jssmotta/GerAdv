'use client';
import { IGridComponent } from '@/app/interfaces/IGridComponent';
import ProSucumbenciaGrid from '@/app/GerAdv_TS/ProSucumbencia/Crud/Grids/ProSucumbenciaGrid';
export class ProSucumbenciaGridAdapter implements IGridComponent {
  render(): React.ReactNode {
    return <ProSucumbenciaGrid />;
  }
}