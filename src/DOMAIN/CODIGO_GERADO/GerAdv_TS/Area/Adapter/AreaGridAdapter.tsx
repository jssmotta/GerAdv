'use client';
import { IGridComponent } from '@/app/interfaces/IGridComponent';
import AreaGrid from '@/app/GerAdv_TS/Area/Crud/Grids/AreaGrid';
export class AreaGridAdapter implements IGridComponent {
  render(): React.ReactNode {
    return <AreaGrid />;
  }
}