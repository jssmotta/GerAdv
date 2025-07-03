// LigacoesGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { LigacoesGridAdapter } from '@/app/GerAdv_TS/Ligacoes/Adapter/LigacoesGridAdapter';
// Mock LigacoesGrid component
jest.mock('@/app/GerAdv_TS/Ligacoes/Crud/Grids/LigacoesGrid', () => () => <div data-testid='ligacoes-grid-mock' />);
describe('LigacoesGridAdapter', () => {
  it('should render LigacoesGrid component', () => {
    const adapter = new LigacoesGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('ligacoes-grid-mock')).toBeInTheDocument();
  });
});