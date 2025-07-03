// HorasTrabGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { HorasTrabGridAdapter } from '@/app/GerAdv_TS/HorasTrab/Adapter/HorasTrabGridAdapter';
// Mock HorasTrabGrid component
jest.mock('@/app/GerAdv_TS/HorasTrab/Crud/Grids/HorasTrabGrid', () => () => <div data-testid='horastrab-grid-mock' />);
describe('HorasTrabGridAdapter', () => {
  it('should render HorasTrabGrid component', () => {
    const adapter = new HorasTrabGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('horastrab-grid-mock')).toBeInTheDocument();
  });
});