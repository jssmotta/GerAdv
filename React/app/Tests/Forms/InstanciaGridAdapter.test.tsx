// InstanciaGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { InstanciaGridAdapter } from '@/app/GerAdv_TS/Instancia/Adapter/InstanciaGridAdapter';
// Mock InstanciaGrid component
jest.mock('@/app/GerAdv_TS/Instancia/Crud/Grids/InstanciaGrid', () => () => <div data-testid='instancia-grid-mock' />);
describe('InstanciaGridAdapter', () => {
  it('should render InstanciaGrid component', () => {
    const adapter = new InstanciaGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('instancia-grid-mock')).toBeInTheDocument();
  });
});