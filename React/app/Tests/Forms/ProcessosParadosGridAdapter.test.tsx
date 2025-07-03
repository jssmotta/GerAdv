// ProcessosParadosGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { ProcessosParadosGridAdapter } from '@/app/GerAdv_TS/ProcessosParados/Adapter/ProcessosParadosGridAdapter';
// Mock ProcessosParadosGrid component
jest.mock('@/app/GerAdv_TS/ProcessosParados/Crud/Grids/ProcessosParadosGrid', () => () => <div data-testid='processosparados-grid-mock' />);
describe('ProcessosParadosGridAdapter', () => {
  it('should render ProcessosParadosGrid component', () => {
    const adapter = new ProcessosParadosGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('processosparados-grid-mock')).toBeInTheDocument();
  });
});