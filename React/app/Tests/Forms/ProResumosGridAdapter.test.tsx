// ProResumosGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { ProResumosGridAdapter } from '@/app/GerAdv_TS/ProResumos/Adapter/ProResumosGridAdapter';
// Mock ProResumosGrid component
jest.mock('@/app/GerAdv_TS/ProResumos/Crud/Grids/ProResumosGrid', () => () => <div data-testid='proresumos-grid-mock' />);
describe('ProResumosGridAdapter', () => {
  it('should render ProResumosGrid component', () => {
    const adapter = new ProResumosGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('proresumos-grid-mock')).toBeInTheDocument();
  });
});