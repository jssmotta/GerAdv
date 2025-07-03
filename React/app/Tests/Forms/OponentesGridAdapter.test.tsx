// OponentesGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { OponentesGridAdapter } from '@/app/GerAdv_TS/Oponentes/Adapter/OponentesGridAdapter';
// Mock OponentesGrid component
jest.mock('@/app/GerAdv_TS/Oponentes/Crud/Grids/OponentesGrid', () => () => <div data-testid='oponentes-grid-mock' />);
describe('OponentesGridAdapter', () => {
  it('should render OponentesGrid component', () => {
    const adapter = new OponentesGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('oponentes-grid-mock')).toBeInTheDocument();
  });
});