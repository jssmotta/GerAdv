// FaseGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { FaseGridAdapter } from '@/app/GerAdv_TS/Fase/Adapter/FaseGridAdapter';
// Mock FaseGrid component
jest.mock('@/app/GerAdv_TS/Fase/Crud/Grids/FaseGrid', () => () => <div data-testid='fase-grid-mock' />);
describe('FaseGridAdapter', () => {
  it('should render FaseGrid component', () => {
    const adapter = new FaseGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('fase-grid-mock')).toBeInTheDocument();
  });
});