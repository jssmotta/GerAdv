// CargosGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { CargosGridAdapter } from '@/app/GerAdv_TS/Cargos/Adapter/CargosGridAdapter';
// Mock CargosGrid component
jest.mock('@/app/GerAdv_TS/Cargos/Crud/Grids/CargosGrid', () => () => <div data-testid='cargos-grid-mock' />);
describe('CargosGridAdapter', () => {
  it('should render CargosGrid component', () => {
    const adapter = new CargosGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('cargos-grid-mock')).toBeInTheDocument();
  });
});