'use client';
import { IGridComponent } from '@/app/interfaces/IGridComponent';
import OperadoresGrid from '@/app/GerAdv_TS/Operadores/Crud/Grids/OperadoresGrid';
export class OperadoresGridAdapter implements IGridComponent {
  render(): React.ReactNode {
    return <OperadoresGrid />;
  }
}