// ObjetosGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { ObjetosGridAdapter } from '@/app/GerAdv_TS/Objetos/Adapter/ObjetosGridAdapter';
// Mock ObjetosGrid component
jest.mock('@/app/GerAdv_TS/Objetos/Crud/Grids/ObjetosGrid', () => () => <div data-testid='objetos-grid-mock' />);
describe('ObjetosGridAdapter', () => {
  it('should render ObjetosGrid component', () => {
    const adapter = new ObjetosGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('objetos-grid-mock')).toBeInTheDocument();
  });
});