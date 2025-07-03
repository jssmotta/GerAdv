// ProPartesGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { ProPartesGridAdapter } from '@/app/GerAdv_TS/ProPartes/Adapter/ProPartesGridAdapter';
// Mock ProPartesGrid component
jest.mock('@/app/GerAdv_TS/ProPartes/Crud/Grids/ProPartesGrid', () => () => <div data-testid='propartes-grid-mock' />);
describe('ProPartesGridAdapter', () => {
  it('should render ProPartesGrid component', () => {
    const adapter = new ProPartesGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('propartes-grid-mock')).toBeInTheDocument();
  });
});