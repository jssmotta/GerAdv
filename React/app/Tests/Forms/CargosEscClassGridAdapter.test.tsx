// CargosEscClassGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { CargosEscClassGridAdapter } from '@/app/GerAdv_TS/CargosEscClass/Adapter/CargosEscClassGridAdapter';
// Mock CargosEscClassGrid component
jest.mock('@/app/GerAdv_TS/CargosEscClass/Crud/Grids/CargosEscClassGrid', () => () => <div data-testid='cargosescclass-grid-mock' />);
describe('CargosEscClassGridAdapter', () => {
  it('should render CargosEscClassGrid component', () => {
    const adapter = new CargosEscClassGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('cargosescclass-grid-mock')).toBeInTheDocument();
  });
});