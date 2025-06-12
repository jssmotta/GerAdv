'use client';
import { IGridComponent } from '@/app/interfaces/IGridComponent';
import GUTPeriodicidadeGrid from '@/app/GerAdv_TS/GUTPeriodicidade/Crud/Grids/GUTPeriodicidadeGrid';
export class GUTPeriodicidadeGridAdapter implements IGridComponent {
  render(): React.ReactNode {
    return <GUTPeriodicidadeGrid />;
  }
}