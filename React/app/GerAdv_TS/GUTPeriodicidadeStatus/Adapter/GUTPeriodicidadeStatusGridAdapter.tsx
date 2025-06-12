'use client';
import { IGridComponent } from '@/app/interfaces/IGridComponent';
import GUTPeriodicidadeStatusGrid from '@/app/GerAdv_TS/GUTPeriodicidadeStatus/Crud/Grids/GUTPeriodicidadeStatusGrid';
export class GUTPeriodicidadeStatusGridAdapter implements IGridComponent {
  render(): React.ReactNode {
    return <GUTPeriodicidadeStatusGrid />;
  }
}