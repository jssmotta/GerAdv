// PaisesGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { PaisesGridAdapter } from '@/app/GerAdv_TS/Paises/Adapter/PaisesGridAdapter';
// Mock PaisesGrid component
jest.mock('@/app/GerAdv_TS/Paises/Crud/Grids/PaisesGrid', () => () => <div data-testid='paises-grid-mock' />);
describe('PaisesGridAdapter', () => {
  it('should render PaisesGrid component', () => {
    const adapter = new PaisesGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('paises-grid-mock')).toBeInTheDocument();
  });
});