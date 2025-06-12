'use client';
import { IGridComponent } from '@/app/interfaces/IGridComponent';
import BensClassificacaoGrid from '@/app/GerAdv_TS/BensClassificacao/Crud/Grids/BensClassificacaoGrid';
export class BensClassificacaoGridAdapter implements IGridComponent {
  render(): React.ReactNode {
    return <BensClassificacaoGrid />;
  }
}