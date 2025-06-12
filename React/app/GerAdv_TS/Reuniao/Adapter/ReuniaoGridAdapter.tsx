'use client';
import { IGridComponent } from '@/app/interfaces/IGridComponent';
import ReuniaoGrid from '@/app/GerAdv_TS/Reuniao/Crud/Grids/ReuniaoGrid';
export class ReuniaoGridAdapter implements IGridComponent {
  render(): React.ReactNode {
    return <ReuniaoGrid />;
  }
}