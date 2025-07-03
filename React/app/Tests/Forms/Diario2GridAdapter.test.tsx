// Diario2GridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { Diario2GridAdapter } from '@/app/GerAdv_TS/Diario2/Adapter/Diario2GridAdapter';
// Mock Diario2Grid component
jest.mock('@/app/GerAdv_TS/Diario2/Crud/Grids/Diario2Grid', () => () => <div data-testid='diario2-grid-mock' />);
describe('Diario2GridAdapter', () => {
  it('should render Diario2Grid component', () => {
    const adapter = new Diario2GridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('diario2-grid-mock')).toBeInTheDocument();
  });
});