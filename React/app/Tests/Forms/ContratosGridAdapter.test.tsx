// ContratosGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { ContratosGridAdapter } from '@/app/GerAdv_TS/Contratos/Adapter/ContratosGridAdapter';
// Mock ContratosGrid component
jest.mock('@/app/GerAdv_TS/Contratos/Crud/Grids/ContratosGrid', () => () => <div data-testid='contratos-grid-mock' />);
describe('ContratosGridAdapter', () => {
  it('should render ContratosGrid component', () => {
    const adapter = new ContratosGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('contratos-grid-mock')).toBeInTheDocument();
  });
});