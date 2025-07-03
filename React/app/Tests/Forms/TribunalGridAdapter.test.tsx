// TribunalGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { TribunalGridAdapter } from '@/app/GerAdv_TS/Tribunal/Adapter/TribunalGridAdapter';
// Mock TribunalGrid component
jest.mock('@/app/GerAdv_TS/Tribunal/Crud/Grids/TribunalGrid', () => () => <div data-testid='tribunal-grid-mock' />);
describe('TribunalGridAdapter', () => {
  it('should render TribunalGrid component', () => {
    const adapter = new TribunalGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('tribunal-grid-mock')).toBeInTheDocument();
  });
});