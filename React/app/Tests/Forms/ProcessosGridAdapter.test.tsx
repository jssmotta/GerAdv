// ProcessosGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { ProcessosGridAdapter } from '@/app/GerAdv_TS/Processos/Adapter/ProcessosGridAdapter';
// Mock ProcessosGrid component
jest.mock('@/app/GerAdv_TS/Processos/Crud/Grids/ProcessosGrid', () => () => <div data-testid='processos-grid-mock' />);
describe('ProcessosGridAdapter', () => {
  it('should render ProcessosGrid component', () => {
    const adapter = new ProcessosGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('processos-grid-mock')).toBeInTheDocument();
  });
});