// UFGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { UFGridAdapter } from '@/app/GerAdv_TS/UF/Adapter/UFGridAdapter';
// Mock UFGrid component
jest.mock('@/app/GerAdv_TS/UF/Crud/Grids/UFGrid', () => () => <div data-testid='uf-grid-mock' />);
describe('UFGridAdapter', () => {
  it('should render UFGrid component', () => {
    const adapter = new UFGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('uf-grid-mock')).toBeInTheDocument();
  });
});