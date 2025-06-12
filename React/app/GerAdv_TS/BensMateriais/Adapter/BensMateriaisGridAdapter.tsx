'use client';
import { IGridComponent } from '@/app/interfaces/IGridComponent';
import BensMateriaisGrid from '@/app/GerAdv_TS/BensMateriais/Crud/Grids/BensMateriaisGrid';
export class BensMateriaisGridAdapter implements IGridComponent {
  render(): React.ReactNode {
    return <BensMateriaisGrid />;
  }
}