'use client';
import { IGridComponent } from '@/app/interfaces/IGridComponent';
import StatusHTrabGrid from '@/app/GerAdv_TS/StatusHTrab/Crud/Grids/StatusHTrabGrid';
export class StatusHTrabGridAdapter implements IGridComponent {
  render(): React.ReactNode {
    return <StatusHTrabGrid />;
  }
}