'use client';
import { IGridComponent } from '@/app/interfaces/IGridComponent';
import AcaoGrid from '@/app/GerAdv_TS/Acao/Crud/Grids/AcaoGrid';
export class AcaoGridAdapter implements IGridComponent {
  render(): React.ReactNode {
    return <AcaoGrid />;
  }
}