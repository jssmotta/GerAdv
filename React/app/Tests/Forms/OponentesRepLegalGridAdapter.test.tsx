// OponentesRepLegalGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { OponentesRepLegalGridAdapter } from '@/app/GerAdv_TS/OponentesRepLegal/Adapter/OponentesRepLegalGridAdapter';
// Mock OponentesRepLegalGrid component
jest.mock('@/app/GerAdv_TS/OponentesRepLegal/Crud/Grids/OponentesRepLegalGrid', () => () => <div data-testid='oponentesreplegal-grid-mock' />);
describe('OponentesRepLegalGridAdapter', () => {
  it('should render OponentesRepLegalGrid component', () => {
    const adapter = new OponentesRepLegalGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('oponentesreplegal-grid-mock')).toBeInTheDocument();
  });
});