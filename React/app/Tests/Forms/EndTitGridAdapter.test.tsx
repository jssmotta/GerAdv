// EndTitGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { EndTitGridAdapter } from '@/app/GerAdv_TS/EndTit/Adapter/EndTitGridAdapter';
// Mock EndTitGrid component
jest.mock('@/app/GerAdv_TS/EndTit/Crud/Grids/EndTitGrid', () => () => <div data-testid='endtit-grid-mock' />);
describe('EndTitGridAdapter', () => {
  it('should render EndTitGrid component', () => {
    const adapter = new EndTitGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('endtit-grid-mock')).toBeInTheDocument();
  });
});