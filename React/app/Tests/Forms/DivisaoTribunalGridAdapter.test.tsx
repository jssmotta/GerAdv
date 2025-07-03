// DivisaoTribunalGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { DivisaoTribunalGridAdapter } from '@/app/GerAdv_TS/DivisaoTribunal/Adapter/DivisaoTribunalGridAdapter';
// Mock DivisaoTribunalGrid component
jest.mock('@/app/GerAdv_TS/DivisaoTribunal/Crud/Grids/DivisaoTribunalGrid', () => () => <div data-testid='divisaotribunal-grid-mock' />);
describe('DivisaoTribunalGridAdapter', () => {
  it('should render DivisaoTribunalGrid component', () => {
    const adapter = new DivisaoTribunalGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('divisaotribunal-grid-mock')).toBeInTheDocument();
  });
});