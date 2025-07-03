// PrecatoriaGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { PrecatoriaGridAdapter } from '@/app/GerAdv_TS/Precatoria/Adapter/PrecatoriaGridAdapter';
// Mock PrecatoriaGrid component
jest.mock('@/app/GerAdv_TS/Precatoria/Crud/Grids/PrecatoriaGrid', () => () => <div data-testid='precatoria-grid-mock' />);
describe('PrecatoriaGridAdapter', () => {
  it('should render PrecatoriaGrid component', () => {
    const adapter = new PrecatoriaGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('precatoria-grid-mock')).toBeInTheDocument();
  });
});