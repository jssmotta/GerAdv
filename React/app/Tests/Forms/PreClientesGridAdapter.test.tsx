// PreClientesGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { PreClientesGridAdapter } from '@/app/GerAdv_TS/PreClientes/Adapter/PreClientesGridAdapter';
// Mock PreClientesGrid component
jest.mock('@/app/GerAdv_TS/PreClientes/Crud/Grids/PreClientesGrid', () => () => <div data-testid='preclientes-grid-mock' />);
describe('PreClientesGridAdapter', () => {
  it('should render PreClientesGrid component', () => {
    const adapter = new PreClientesGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('preclientes-grid-mock')).toBeInTheDocument();
  });
});