// ProValoresGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { ProValoresGridAdapter } from '@/app/GerAdv_TS/ProValores/Adapter/ProValoresGridAdapter';
// Mock ProValoresGrid component
jest.mock('@/app/GerAdv_TS/ProValores/Crud/Grids/ProValoresGrid', () => () => <div data-testid='provalores-grid-mock' />);
describe('ProValoresGridAdapter', () => {
  it('should render ProValoresGrid component', () => {
    const adapter = new ProValoresGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('provalores-grid-mock')).toBeInTheDocument();
  });
});