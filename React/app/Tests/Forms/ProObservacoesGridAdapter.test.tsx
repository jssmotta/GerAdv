// ProObservacoesGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { ProObservacoesGridAdapter } from '@/app/GerAdv_TS/ProObservacoes/Adapter/ProObservacoesGridAdapter';
// Mock ProObservacoesGrid component
jest.mock('@/app/GerAdv_TS/ProObservacoes/Crud/Grids/ProObservacoesGrid', () => () => <div data-testid='proobservacoes-grid-mock' />);
describe('ProObservacoesGridAdapter', () => {
  it('should render ProObservacoesGrid component', () => {
    const adapter = new ProObservacoesGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('proobservacoes-grid-mock')).toBeInTheDocument();
  });
});