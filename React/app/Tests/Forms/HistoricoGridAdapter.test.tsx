// HistoricoGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { HistoricoGridAdapter } from '@/app/GerAdv_TS/Historico/Adapter/HistoricoGridAdapter';
// Mock HistoricoGrid component
jest.mock('@/app/GerAdv_TS/Historico/Crud/Grids/HistoricoGrid', () => () => <div data-testid='historico-grid-mock' />);
describe('HistoricoGridAdapter', () => {
  it('should render HistoricoGrid component', () => {
    const adapter = new HistoricoGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('historico-grid-mock')).toBeInTheDocument();
  });
});