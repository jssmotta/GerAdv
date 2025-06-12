'use client';
import { IGridComponent } from '@/app/interfaces/IGridComponent';
import SituacaoGrid from '@/app/GerAdv_TS/Situacao/Crud/Grids/SituacaoGrid';
export class SituacaoGridAdapter implements IGridComponent {
  render(): React.ReactNode {
    return <SituacaoGrid />;
  }
}