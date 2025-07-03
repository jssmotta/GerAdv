// Apenso2GridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { Apenso2GridAdapter } from '@/app/GerAdv_TS/Apenso2/Adapter/Apenso2GridAdapter';
// Mock Apenso2Grid component
jest.mock('@/app/GerAdv_TS/Apenso2/Crud/Grids/Apenso2Grid', () => () => <div data-testid='apenso2-grid-mock' />);
describe('Apenso2GridAdapter', () => {
  it('should render Apenso2Grid component', () => {
    const adapter = new Apenso2GridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('apenso2-grid-mock')).toBeInTheDocument();
  });
});