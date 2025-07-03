// CargosEscGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { CargosEscGridAdapter } from '@/app/GerAdv_TS/CargosEsc/Adapter/CargosEscGridAdapter';
// Mock CargosEscGrid component
jest.mock('@/app/GerAdv_TS/CargosEsc/Crud/Grids/CargosEscGrid', () => () => <div data-testid='cargosesc-grid-mock' />);
describe('CargosEscGridAdapter', () => {
  it('should render CargosEscGrid component', () => {
    const adapter = new CargosEscGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('cargosesc-grid-mock')).toBeInTheDocument();
  });
});