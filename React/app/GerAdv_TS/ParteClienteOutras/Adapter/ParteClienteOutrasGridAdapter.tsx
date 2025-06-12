'use client';
import { IGridComponent } from '@/app/interfaces/IGridComponent';
import ParteClienteOutrasGrid from '@/app/GerAdv_TS/ParteClienteOutras/Crud/Grids/ParteClienteOutrasGrid';
export class ParteClienteOutrasGridAdapter implements IGridComponent {
  render(): React.ReactNode {
    return <ParteClienteOutrasGrid />;
  }
}