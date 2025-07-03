// AnexamentoRegistrosGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { AnexamentoRegistrosGridAdapter } from '@/app/GerAdv_TS/AnexamentoRegistros/Adapter/AnexamentoRegistrosGridAdapter';
// Mock AnexamentoRegistrosGrid component
jest.mock('@/app/GerAdv_TS/AnexamentoRegistros/Crud/Grids/AnexamentoRegistrosGrid', () => () => <div data-testid='anexamentoregistros-grid-mock' />);
describe('AnexamentoRegistrosGridAdapter', () => {
  it('should render AnexamentoRegistrosGrid component', () => {
    const adapter = new AnexamentoRegistrosGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('anexamentoregistros-grid-mock')).toBeInTheDocument();
  });
});