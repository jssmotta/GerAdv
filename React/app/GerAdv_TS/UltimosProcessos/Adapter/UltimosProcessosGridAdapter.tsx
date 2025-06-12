'use client';
import { IGridComponent } from '@/app/interfaces/IGridComponent';
import UltimosProcessosGrid from '@/app/GerAdv_TS/UltimosProcessos/Crud/Grids/UltimosProcessosGrid';
export class UltimosProcessosGridAdapter implements IGridComponent {
  render(): React.ReactNode {
    return <UltimosProcessosGrid />;
  }
}