'use client';
import { IGridComponent } from '@/app/interfaces/IGridComponent';
import ParceriaProcGrid from '@/app/GerAdv_TS/ParceriaProc/Crud/Grids/ParceriaProcGrid';
export class ParceriaProcGridAdapter implements IGridComponent {
  render(): React.ReactNode {
    return <ParceriaProcGrid />;
  }
}