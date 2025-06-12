'use client';
import { IGridComponent } from '@/app/interfaces/IGridComponent';
import OperadorGruposGrid from '@/app/GerAdv_TS/OperadorGrupos/Crud/Grids/OperadorGruposGrid';
export class OperadorGruposGridAdapter implements IGridComponent {
  render(): React.ReactNode {
    return <OperadorGruposGrid />;
  }
}