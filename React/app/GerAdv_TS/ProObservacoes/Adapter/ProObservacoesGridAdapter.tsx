'use client';
import { IGridComponent } from '@/app/interfaces/IGridComponent';
import ProObservacoesGrid from '@/app/GerAdv_TS/ProObservacoes/Crud/Grids/ProObservacoesGrid';
export class ProObservacoesGridAdapter implements IGridComponent {
  render(): React.ReactNode {
    return <ProObservacoesGrid />;
  }
}