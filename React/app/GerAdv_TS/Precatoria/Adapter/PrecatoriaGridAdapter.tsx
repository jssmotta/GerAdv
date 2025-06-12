'use client';
import { IGridComponent } from '@/app/interfaces/IGridComponent';
import PrecatoriaGrid from '@/app/GerAdv_TS/Precatoria/Crud/Grids/PrecatoriaGrid';
export class PrecatoriaGridAdapter implements IGridComponent {
  render(): React.ReactNode {
    return <PrecatoriaGrid />;
  }
}